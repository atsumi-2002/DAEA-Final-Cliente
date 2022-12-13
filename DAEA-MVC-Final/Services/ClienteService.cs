using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAEA_MVC_Final.Models;
using Newtonsoft.Json;

namespace DAEA_MVC_Final.Services
{
    public class ClienteService
    {
        public async Task<List<Cliente>> Lista()
        {
            List<Cliente> lista = new List<Cliente>();

            var clt = new HttpClient();
            clt.BaseAddress = new Uri("http");
            var response = await clt.GetAsync("api/cliente/lista");
            
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoAPI>(json_response);
                lista = resultado.ListaC;
            }
            return lista;
        }
        public async Task<bool> Guardar(Cliente objeto)
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
        public async Task<bool> Editar(Cliente objeto)
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
        public async Task<Cliente> Obtener(int ClienteID)
        {
            Cliente objeto = new Cliente();

            var clt = new HttpClient();
            clt.BaseAddress = new Uri("http");
            var response = await clt.GetAsync($"api/cliente/obtener/{ClienteID}");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoAPI>(json_response);
                objeto = resultado.Cliente;
            }
            return objeto;
        }
    } 
}