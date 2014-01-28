using System;
using System.Collections.Generic;
using System.Web;
using System.Text;

namespace Common
{
    public class UrlSecuring
    {
        public static string AddUrlParameter(string Url, string ParameterName, string ParameterValue)
        {
            string myRawUrl = "";
            string myQstr = "";

            if (Url.IndexOf('?') > 0)
            {
                myRawUrl = Url.Split('?')[0];

                myQstr = Url.Split('?')[1];
                myQstr = EncryptionUtility.Decrypt(HttpUtility.UrlDecode(myQstr));
                myQstr += "&";
            }
            else
                myRawUrl = Url;

            myQstr += ParameterName.Trim() + "=" + ParameterValue.Trim();

            string myUrl = myRawUrl + "?" + HttpUtility.UrlEncode(EncryptionUtility.Encrypt(myQstr));

            return myUrl;
        }

        public static string DecryptUrl(string Url)
        {
            Uri myUri = new Uri(Url);
            string myRawUrl = myUri.AbsoluteUri.Substring(0, myUri.AbsoluteUri.Length - myUri.Query.Length);
            string myQstr = myUri.Query.TrimStart('?');

            string myUrl;

            if (myQstr.Length > 0)
                myUrl = myRawUrl + "?" + EncryptionUtility.Decrypt(HttpUtility.UrlDecode(myQstr));
            else
                myUrl = myRawUrl;

            return myUrl;
        }

        public static string GetParameterValue(string Url, string ParamName)
        {
            string OpenUrl;
            try
            {
                OpenUrl = DecryptUrl(Url);

                if (string.IsNullOrEmpty(OpenUrl))
                    return "";

                Uri OpenUri = new Uri(OpenUrl);

                return HttpUtility.ParseQueryString(OpenUri.Query).Get(ParamName);
            }
            catch (Exception)
            {
                return "";
            }

        }
    }
}
