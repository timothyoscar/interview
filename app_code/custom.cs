using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for @class
/// </summary>
/// 
namespace custom
{
    public class customInfo
    {
        private string _fullName = string.Empty;
        private string _lastName = string.Empty;
        private string _fileInput = "unsorted-names-list.txt";
        private string _fileOutput = string.Empty;

        public string fullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string fileInput
        {
            get { return _fileInput; }
            set { _fileInput = value; }
        }
        public string fileOutput
        {
            get { return _fileOutput; }
            set { _fileOutput = value; }
        }
    }
    public class customControl
    {
        
        public enum SaveType
        {
            Insert = 0,
            Update = 1
        }
        /////////////////
        //Get Complete Data
        public List<customInfo> GetData(StreamReader sr)
        {
            try
            {
                string strContents = sr.ReadToEnd();
                List<customInfo> objListCustom_Info = new List<customInfo>();
                customInfo objCustomInfo;

                string[] str = strContents.Split('\n');

                foreach (string sub in str)
                {
                    strContents = strContents.Substring(strContents.IndexOf("\n"));

                    objCustomInfo = new customInfo();
                    objCustomInfo.fullName = (string)sub;
                    objCustomInfo.lastName = (string)sub.Split(' ').Last();
                    
                    objListCustom_Info.Add(objCustomInfo);
                }

                objListCustom_Info = objListCustom_Info.OrderBy(o => o.lastName).ToList();

                return objListCustom_Info;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #region sortFunction
        /////////////////
        //by LastName
        public List<customInfo> sortbyLastName(List<customInfo> objListCustom_Info)
        {
            try
            {
                objListCustom_Info = objListCustom_Info.OrderBy(o => o.lastName).ToList();
                return objListCustom_Info;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}