using Newtonsoft.Json;
using RestSharp;
using Sl1_Front.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Sl1_Front.ServiceAPI
{
    public class AuthAPIService
    {
        public static HttpWebRequest GetRequestAPI(string endpoint, string method)
        {

            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://localhost:44349/api/" + endpoint);
                var JWT = GetJWT();
                request.Headers.Add("Authorization", "Bearer " + JWT);
                request.Method = method;
                return request;
            }
            catch (Exception ex)
            {
                _ = ex.ToString();
                return null;
            }

        }

        private static string GetJWT()
        {
            string JWT = ""; 
            ResponseToken token = new ResponseToken();
            try
            {
                var usuario = "krispy";
                var contrasenia = "kr1py1234";
                var client = new RestClient("https://localhost:44349/api");
                var request = new RestRequest("auth", Method.Post);
                request.AddBody(new
                {
                    Usuario = usuario,
                    Clave = contrasenia
                });
                var response = client.ExecutePost(request);
                token = JsonConvert.DeserializeObject<ResponseToken>(response.Content);
                JWT = token.Token;
            }
            catch (Exception ex)
            {
                _ = ex.ToString();
                return null;
            }
            return JWT;
        }

    }
}
