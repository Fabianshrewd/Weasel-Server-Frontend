using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Weasel_Server_MapViewer
{
    internal class GETRequestMap
    {
        private static string _Result;

        public static string Result { get { return _Result; } }

        public static async void Request(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        _Result = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        _Result = null;
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    _Result = null;
                }
            }
        }
    }
}
