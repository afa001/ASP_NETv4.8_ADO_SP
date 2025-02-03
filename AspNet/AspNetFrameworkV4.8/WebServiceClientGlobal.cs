using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AspNetFrameworkV4._8.Models;

namespace AspNetFrameworkV4._8.Controllers
{
    public class WebServiceClientGlobal
    {
        private readonly HttpClient _httpClient;

        public WebServiceClientGlobal()
        {
            // Configurar para ignorar validación de certificados
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };


            //_httpClient = new HttpClient() 
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7126/api/")
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<TblClientes>> GetAllClientesAsync()
        {
            var response = await _httpClient.GetAsync("Clientes");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<TblClientes>>();
        }

        public async Task<TblClientes> GetClienteByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Clientes/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<TblClientes>();
        }

        public async Task AddClienteAsync(TblClientes cliente)
        {
            var response = await _httpClient.PostAsJsonAsync("Clientes", cliente);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateClienteAsync(int id, TblClientes cliente)
        {
            var response = await _httpClient.PutAsJsonAsync($"Clientes/{id}", cliente);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Clientes/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<CatTipoCliente>> GetAllTiposClientesAsync()
        {
            var response = await _httpClient.GetAsync("TipoCliente");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<CatTipoCliente>>();
        }

        public async Task<CatTipoCliente> GetAllTiposClientesByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"TipoCliente/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<CatTipoCliente>();
        }
    }
}