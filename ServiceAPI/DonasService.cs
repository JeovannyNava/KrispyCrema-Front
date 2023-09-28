using Newtonsoft.Json;
using Sl1_Front.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Sl1_Front.ServiceAPI
{
    public class DonasService
    {
        public List<Dona> GetDonas()
        {
            var donas = new List<Dona>();
            try
            {
 
                var request = AuthAPIService.GetRequestAPI("donas", "get");
                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                string jsonResponse = reader.ReadToEnd();
                donas = JsonConvert.DeserializeObject<List<Dona>>(jsonResponse);

            }
            catch (Exception ex)
            {
                _ = ex.ToString();

            }
            return donas;
        }
    }


}