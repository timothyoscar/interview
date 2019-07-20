using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using custom;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string inputFile = "unsorted-names-list.txt";
        string outputFile = "sorted-names-list.txt";
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
}