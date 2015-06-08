using System;
using System.Net;
using System.IO;
using System.Net.Http;
using HtmlAnalyser.Log;

namespace HtmlAnalyser.HTTPHelper
{
    public class HttpHelper
    {
        private string _userAgent;
        private IHttpStreamReader _reader;
        private IHttpStreamWriter _writer;

        public HttpHelper()
        {
            _userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            _reader = new StringReader();
            _writer = new StringWriter();
        }

        public string Request(string url)
        {
            return Request(url, HttpMethod.Get, null);
        }

        public string Request(string url, HttpMethod method, string data)
        {
            if (string.IsNullOrEmpty(url))
            {
                LogWritor.Error("HttpHelper.Request: null url.");
                return "";
            }

            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = method.ToString();
                request.UserAgent = _userAgent;

                if (!string.IsNullOrEmpty(data))
                {
                    Stream stream = request.GetRequestStream();
                    _writer.Write(stream, data);
                }

                WebResponse response = request.GetResponse();
                Stream rs = response.GetResponseStream();

                return _reader.Read(rs);
            }
            catch (Exception ex)
            {
                LogWritor.Error(url, "HttpHelper.Request fail:" + ex.Message);
                return null;
            }
        }
    }
}