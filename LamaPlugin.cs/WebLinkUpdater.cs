using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.IO.Compression;


namespace LamaPlugin
{
    public class WebLinkUpdater : UpdateMethod
    {
        WebClient client;


        public WebLinkUpdater(string link, Version version) : base(link) {
            this.client = new WebClient();
            this.version = version;
            this.link = link;
            this.client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

        }


        public override bool CheckVersion()
        {
            Stream s = this.client.OpenRead(link + "lastest_version");
            StreamReader sr = new StreamReader(s);
            string v = sr.ReadToEnd();
            s.Close();

            int.TryParse(v.Replace(".", ""), out int remoteV);
            int.TryParse(this.version.ToString().Replace(".", ""), out int localV);
           
            return (localV >= remoteV);
        }

        public override string DownLoad(string finalPath)
        {
            this.client.DownloadFile(this.link + "lastest_files.zip", finalPath);
            GZipStream gzs = new GZipStream(File.OpenRead(finalPath + "lastest_files.zip"), CompressionMode.Decompress);
         
            return "";
        }
    }
}
