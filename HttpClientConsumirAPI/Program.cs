using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace HttpClientconsumirAPI
{
    class Program
    {
        private static readonly HttpClient client = new();

        static async Task Main(string[] args)
        {
            void AguardarTecla()
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }

            string url = "https://[SEU_HOST].tryasp.net/api/Pessoa";
            bool continuarRodando = true;

            // O laço 'while' vai repetir tudo o que está dentro dele
            while (continuarRodando)
            {

                int Opcao = ObterOpcaoMenu();
                Console.WriteLine($"\nSucesso! Você escolheu a opção: {Opcao}");

                switch (Opcao)
                {
                    case 1:

                        try
                        {
                            var dadosObjeto = new
                            {
                                razaoSocial = "TesteERPSimples",
                                cnpjCpf = "99.999.999/0001-99",
                                email = "erpsimples@gmail.com",
                                telefone = "99999999999",
                                usuario = "TesteERPSimples",
                                senha = "123123"
                            };

                            string data_inclusao = Newtonsoft.Json.JsonConvert.SerializeObject(dadosObjeto);

                            // 2. Montamos o conteúdo configurando o formato JSON e a codificação UTF-8 de forma limpa
                            var conteudo = new StringContent(data_inclusao, System.Text.Encoding.UTF8, "application/json");

                            // 3. Fazemos o envio em formato POST
                            var resposta = client.PostAsync(url, conteudo).Result;

                            // 4. Lemos o texto que o servidor respondeu (seja sucesso ou erro)
                            string result = resposta.Content.ReadAsStringAsync().Result;

                            // 5. Verificamos se o servidor aceitou o cadastro
                            if (resposta.IsSuccessStatusCode)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n[Sucesso] Registro incluído com sucesso!");
                                Console.ResetColor();
                            }
                            else
                            {
                                // Se der erro 400, 415, etc., o código cai aqui sem travar o programa!
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\n[Erro {(int)resposta.StatusCode}] Falha ao incluir registro.");
                                Console.WriteLine($"Motivo do servidor: {result}");
                                Console.ResetColor();
                            }
                           
                        }
                        catch (Exception e)
                        {
                            // Captura erros de conexão (ex: URL errada ou servidor fora do ar)
                            Console.WriteLine($"\nErro de comunicação: {e.Message}");
                        }

                        AguardarTecla();
                        break;

                    case 2:

                        try
                        {
                            string codigoAlteracao = ObterCodigoRegistroPorTamanho();
                            Console.WriteLine($"\nCódigo aceito! Você digitou: {codigoAlteracao}");

                            var dadosObjeto = new
                            {
                                idPessoa = int.Parse(codigoAlteracao),
                                razaoSocial = "TesteERPSimples",
                                cnpjCpf = "11.111.111/9999-11",
                                email = "erpsimples@gmail.com",
                                telefone = "99999999999",
                                usuario = "TesteERPSimples",
                                senha = "999999"
                            };

                            string data_alteracao = Newtonsoft.Json.JsonConvert.SerializeObject(dadosObjeto);
                            string url_alteracao = url;

                            // 2. Montamos o conteúdo JSON com codificação UTF-8
                            var conteudo = new StringContent(data_alteracao, System.Text.Encoding.UTF8, "application/json");

                            // 3. Fazemos o envio usando o método PUT
                            var resposta = client.PutAsync(url_alteracao, conteudo).Result;

                            // 4. Lemos a resposta do servidor (sucesso ou erro)
                            string result = resposta.Content.ReadAsStringAsync().Result;

                            // 5. Tratamos o retorno da API
                            if (resposta.IsSuccessStatusCode)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n[Sucesso] Registro alterado com sucesso!");
                                Console.ResetColor();
                            }
                            else
                            {
                                // Se o servidor rejeitar (Erro 400, 404, etc.), exibe o motivo real aqui
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\n[Erro {(int)resposta.StatusCode}] Falha ao alterar o registro.");
                                Console.WriteLine($"Motivo do servidor: {result}");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception e)
                        {
                            // Captura erros graves de comunicação ou falha no int.Parse() se o código não for número
                            Console.WriteLine($"\nErro na operação de alteração: {e.Message}");
                        }

                        AguardarTecla();
                        break;

                    case 3:

                        try
                        {
                            string codigoExclusao = ObterCodigoRegistroPorTamanho();
                            Console.WriteLine($"\nCódigo aceito! Você digitou: {codigoExclusao}");

                            // 1. Montamos a URL específica do registro que será apagado
                            string url_exclusao = url + "/" + codigoExclusao;

                            // 3. Fazemos a requisição DELETE direta (sem precisar de corpo de dados vazios)
                            var resposta = client.DeleteAsync(url_exclusao).Result;

                            // 4. Lemos o retorno do servidor (seja sucesso ou erro)
                            string result = resposta.Content.ReadAsStringAsync().Result;

                            // 5. Tratamos o retorno da API de forma amigável
                            if (resposta.IsSuccessStatusCode)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n[Sucesso] Registro excluído com sucesso!");
                                Console.ResetColor();
                            }
                            else
                            {
                                // Se der erro 400, 404, etc., o código mostra o motivo sem travar o app
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\n[Erro {(int)resposta.StatusCode}] Falha ao excluir o registro.");
                                Console.WriteLine($"Motivo do servidor: {result}");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception e)
                        {
                            // Captura erros de rede ou conexão com o servidor
                            Console.WriteLine($"\nErro na operação de exclusão: {e.Message}");
                        }

                        AguardarTecla();
                        break;

                    case 4:

                        try
                        {
                            Console.WriteLine("Buscando lista de registros...");

                            // 2. Fazemos a requisição GET para puxar os dados
                            var resposta = client.GetAsync(url).Result;

                            // 3. Lemos o texto do JSON retornado pelo servidor
                            string jsonResposta = resposta.Content.ReadAsStringAsync().Result;

                            // 4. Verificamos se a requisição deu certo (Código 200 OK)
                            if (resposta.IsSuccessStatusCode)
                            {
                                // Convertemos para a classe RespostaRegistros
                                var respostaObjeto = Newtonsoft.Json.JsonConvert.DeserializeObject<RespostaRegistros>(jsonResposta);

                                // Pegamos a lista que está dentro da propriedade .data
                                var listaDeRegistros = respostaObjeto?.data;

                                if (listaDeRegistros != null && listaDeRegistros.Count > 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\nSucesso! Encontrados {listaDeRegistros.Count} registros:\n");
                                    Console.ResetColor();

                                    // 5. O foreach roda normalmente pela lista correta
                                    foreach (var registro in listaDeRegistros)
                                    {
                                        Console.WriteLine($"ID: {registro.idPessoa} | Nome: {registro.razaoSocial} | CnpjCpf: {registro.cnpjCpf} | Email: {registro.email} | Telefone: {registro.telefone} | Usuário: {registro.usuario} | Senha: {registro.senha}");
                                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nNenhum registro foi encontrado no servidor.");
                                }
                            }
                            else
                            {
                                // Se o servidor der erro (400, 404, 500, etc.), mostra o erro sem travar
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\n[Erro {(int)resposta.StatusCode}] Falha ao listar os registros.");
                                Console.WriteLine($"Motivo do servidor: {jsonResposta}");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception e)
                        {
                            // Captura erros de conexão, internet caída ou falha na conversão do JSON
                            Console.WriteLine($"\nErro na operação de listagem: {e.Message}");
                        }

                        AguardarTecla();
                        break;

                    case 5:

                        string codigoConsulta = ObterCodigoRegistroPorTamanho();
                        Console.WriteLine($"\nCódigo aceito! Você digitou: {codigoConsulta}");

                        string url_consulta = url + "/" + codigoConsulta;

                        try
                        {
                            Console.WriteLine($"\nBuscando registro com ID {codigoConsulta}...");

                            // 1. Faz o GET usando HttpClient para a URL do registro único
                            var resposta = client.GetAsync(url_consulta).Result;

                            // 2. Lê o texto do JSON retornado pelo servidor
                            string jsonResposta = resposta.Content.ReadAsStringAsync().Result;

                            // 3. Verifica se a requisição foi bem-sucedida (Código 200 OK)
                            if (resposta.IsSuccessStatusCode)
                            {
                                // Converte o JSON usando a classe de objeto único
                                var respostaObjeto = Newtonsoft.Json.JsonConvert.DeserializeObject<RespostaRegistroUnico>(jsonResposta);

                                // Pegamos o registro que está dentro da propriedade .data
                                var registro = respostaObjeto?.data;

                                if (registro != null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n--- REGISTRO ENCONTRADO ---");
                                    Console.WriteLine($"ID: {registro.idPessoa}");
                                    Console.WriteLine($"Razão Social: {registro.razaoSocial}");
                                    Console.WriteLine($"CnpjCpf: {registro.cnpjCpf}");
                                    Console.WriteLine($"Email: {registro.email}");
                                    Console.WriteLine($"Telefone: {registro.telefone}");
                                    Console.WriteLine($"Usuário: {registro.usuario}");
                                    Console.WriteLine($"Senha: {registro.senha}");
                                    Console.WriteLine("----------------------------");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.WriteLine("Nenhum dado encontrado para este ID.");
                                }
                            }
                            else
                            {
                                // Se o ID não existir (404) ou der outro erro, exibe o motivo sem travar o app
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\n[Erro {(int)resposta.StatusCode}] Falha ao buscar o registro.");
                                Console.WriteLine($"Motivo do servidor: {jsonResposta}");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception ex)
                        {
                            // Captura erros de rede ou falhas gerais de comunicação
                            Console.WriteLine($"Erro na busca: {ex.Message}");
                        }

                        AguardarTecla();
                        break;

                    case 6:
                        Console.WriteLine("\nSaindo do sistema... Até logo!");
                        continuarRodando = false; // Muda para false para quebrar o 'while' e encerrar
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida! Tente novamente.");
                        AguardarTecla();
                        break;
                }
            }
        }

        static int ObterOpcaoMenu()
        {
            int numero;
            bool entradaValida = false;

            while (!entradaValida)
            {
                Console.WriteLine("Digite a Opção desejada:");
                Console.WriteLine("1 - para INSERT");
                Console.WriteLine("2 - para UPDATE");
                Console.WriteLine("3 - para DELETE");
                Console.WriteLine("4 - para CONSULTAR TODOS");
                Console.WriteLine("5 - para CONSULTAR unico Registro");
                Console.WriteLine("6 - Sair do Programa");
                Console.Write("\nEscolha uma opção: ");

                string? entrada = Console.ReadLine();

                // 1. Verifica se é um número
                if (int.TryParse(entrada, out numero) && numero >= 1 && numero <= 6)
                {
                    entradaValida = true;
                    return numero;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Erro: Digite apenas os números 1, 2, 3, 4, 5, 6.\n");
                }
            }

            return 0;
        }

        // Função que valida o tamanho do código de registro (1 a 18 caracteres)
        static string ObterCodigoRegistroPorTamanho()
        {
            while (true)
            {
                Console.WriteLine("Digite o código de registro (de 1 a 18 números):");
                string? entrada = Console.ReadLine();

                // 1. Verifica se o tamanho do texto está entre 1 e 18
                // 2. Verifica se o texto contém apenas números
                if (entrada?.Length >= 1 && entrada.Length <= 18 && ApenasNumeros(entrada))
                {
                    return entrada; // Retorna o código válido e sai da função
                }

                Console.Clear();
                Console.WriteLine("Erro: O código deve ter entre 1 e 18 números. Tente de novo.\n");
            }
        }

        // Função auxiliar para garantir que o texto só possui números
        static bool ApenasNumeros(string texto)
        {
            // Se o texto for vazio, já não é válido
            if (string.IsNullOrEmpty(texto)) return false;

            foreach (char c in texto)
            {
                if (!char.IsDigit(c))
                {
                    return false; // Encontrou uma letra, espaço ou símbolo
                }
            }
            return true; // Só tem números
        }
    }

    public class Registro
    {
        public int idPessoa { get; set; }
        public string? razaoSocial { get; set; }
        public string? cnpjCpf { get; set; }
        public string? email { get; set; }
        public string? telefone { get; set; }
        public string? usuario { get; set; }
        public string? senha { get; set; }

    }

    // Essa classe representa a resposta do servidor que carrega a lista dentro de "data"
    public class RespostaRegistros
    {
        public List<Registro> data { get; set; }
    }

    public class RespostaRegistroUnico
    {
        public Registro data { get; set; } // Aqui é um 'Registro' único, não uma List!
    }
}
