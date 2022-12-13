using DAEA_MVC_Final.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAEA_MVC_Final.Services
{
    public class DetallesFactService
    {
        public async Task<List<Detalles_Factura>> Lista()
        {
            List<Detalles_Factura> lista = new List<Detalles_Factura>();

            var clt = new HttpClient();
            clt.BaseAddress = new Uri("http");
            var response = await clt.GetAsync("api/cliente/lista");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoAPI>(json_response);
                lista = resultado.ListaD;
            }
            return lista;
        }
        public async Task<bool> Guardar(Detalles_Factura objeto)
        {
            bool respuesta = false;

            var clt = new HttpClient();
            clt.BaseAddress = new Uri("http");
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await clt.PostAsync("api/cliente/Crear", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
        public async Task<bool> Editar(Detalles_Factura objeto)
        {
            bool respuesta = false;

            var clt = new HttpClient();
            clt.BaseAddress = new Uri("http");
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await clt.PutAsync("api/cliente/update", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
        public async Task<bool> Eliminar(int ClienteID)
        {
            bool respuesta = false;

            var clt = new HttpClient();
            clt.BaseAddress = new Uri("http");
            var response = await clt.DeleteAsync($"api/cliente/obtener/{ClienteID}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
        public async Task<Detalles_Factura> Obtener(int ClienteID)
        {
            Detalles_Factura objeto = new Detalles_Factura();

            var clt = new HttpClient();
            clt.BaseAddress = new Uri("http");
            var response = await clt.GetAsync($"api/cliente/obtener/{ClienteID}");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoAPI>(json_response);
                objeto = resultado.Detalles_Factura;
            }
            return objeto;
        }
    }
}