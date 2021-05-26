using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PokemonPartyConsoleApp.Class
{
    class SystemUtility
    {
        public SystemUtility()
        {

        }
        public static byte[] JsonHttpGetByte(byte[] jsonRequest, string requestUrl)
        {
            string jsonResponse = string.Empty;

            using (var webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                webClient.Headers[HttpRequestHeader.Accept] = "application/json";
                return webClient.DownloadData(requestUrl);
            }
        }
    }
}
