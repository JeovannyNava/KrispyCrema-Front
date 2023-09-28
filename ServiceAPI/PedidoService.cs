using Newtonsoft.Json;
using Sl1_Front.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Sl1_Front.ServiceAPI
{
    public class PedidoService
    {
        public ReponseAPI CrearPedido(Pedido pedido)
        {
            ReponseAPI response = new ReponseAPI();
            var request = AuthAPIService.GetRequestAPI("pedido", "post");
            request.ContentType = "application/json";
            var data = JsonConvert.SerializeObject(pedido);
            byte[] dataStream = Encoding.UTF8.GetBytes(data);
     
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(dataStream, 0, dataStream.Length);
                }
            
            var responseAPI = request.GetResponse();
            var reader = new StreamReader(responseAPI.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            var a = JsonConvert.DeserializeObject<string>(jsonResponse);

            return response;
        }   
        public List<Pedido> GetPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();
            ReponseAPI response = new ReponseAPI();
            var request = AuthAPIService.GetRequestAPI("pedido", "get");
            var responseAPI = request.GetResponse();
            var reader = new StreamReader(responseAPI.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            pedidos = JsonConvert.DeserializeObject<List<Pedido>>(jsonResponse);

            return pedidos;
        }
    }
}