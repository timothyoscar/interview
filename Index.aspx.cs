using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using custom;

public partial class _index : System.Web.UI.Page
{
    string inputFile = "unsorted-names-list.txt";
    string outputFile = "sorted-names-list.txt";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void SortButton_Click()
    {
        List<customInfo> objListCustom_Info = new List<customInfo>();
        customControl objCustom = new customControl();

        String result = "";
        try
        {
            if (File.Exists(Server.MapPath(inputFile)))
            {
                StreamReader sr = File.OpenText(Server.MapPath(inputFile));

                objListCustom_Info = objCustom.GetData(sr);

                foreach (customInfo custom in objListCustom_Info)
                {
                    //Response.Write(custom.fullName + "</br>");
                    result += custom.fullName + "\n";
                }
                if (!File.Exists(Server.MapPath(outputFile)))
                    File.Create(Server.MapPath(outputFile)).Close();


                File.WriteAllText(Server.MapPath(outputFile).ToString(), result);

                sr.Close();
                Response.Write("Success!");
            }
            else
                Response.Write("Failed!");

        }
        catch (Exception ex)
        {
            Response.Write("Failed!");
        }
    }

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFile)
        {
            try
            {
                string filename = Path.GetFileName(FileUploadControl.FileName);
                if (filename != inputFile)
                {
                    StatusLabel.Text = "File name should be: " + inputFile + ". Please rename your file";
                }
                else
                {
                    FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                    SortButton_Click();

                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }
    protected void DownloadButton_Click(object sender, EventArgs e)
    {
        if (File.Exists(Server.MapPath(outputFile)))
        {

            var file = Server.MapPath(outputFile);
            Response.AppendHeader("content-disposition", "attachment; filename=" + outputFile );
            // Open/Save dialog
            Response.ContentType = "application/octet-stream";
            // Push it!
            Response.TransmitFile(file);
        }
    }
}