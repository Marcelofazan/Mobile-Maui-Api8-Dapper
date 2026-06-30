using AppMobile.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace AppMobile.Service
{
    public static class PessoaService
    {
        public const string url = "https://[LINKWEB].tryasp.net/api/pessoa";

        public static async Task<List<Pessoa>> GetPessoasAsync()  
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    string errorDetail = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(errorDetail);
                }

                if (response.IsSuccessStatusCode)
                {

                    var responseBody = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    JsonNode nodos = JsonNode.Parse(responseBody);

                    var root = JsonDocument.Parse(nodos.ToString());
                    var listaJson = root.RootElement.GetProperty("data").GetRawText();
                    var Pessoas = JsonSerializer.Deserialize<List<Pessoa>>(listaJson, options);
                    return Pessoas;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }

            return new List<Pessoa>();
        }

        public static async Task AddPessoaAsync(Pessoa pessoa)
        {
            try
            {
                var url = "https://[LINKWEB].tryasp.net/api/pessoa";

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Faz o POST
                HttpResponseMessage response = await client.PostAsJsonAsync(url, pessoa);

                if (!response.IsSuccessStatusCode)
                {
                    string errorDetail = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(errorDetail); 
                }

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    // Sucesso!
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na requisição: {ex.Message}");
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
