using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace CSHARP_HTTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool encerrarPrograma = false;
            Console.WriteLine("☺ Seja bem vindo ao program de listagem WEB ☺");

            while (!encerrarPrograma)
            {
                Console.WriteLine("\n► Opções ");
                Console.WriteLine("1- Lista Completa");
                Console.WriteLine("2- Lista Parcial");
                Console.WriteLine("3- Encerrar o programa");

                int opEscolhida = int.Parse(Console.ReadLine());

                if (opEscolhida > 0 || opEscolhida < 4)
                {
                    switch (opEscolhida)
                    {
                        case 1:
                            Console.Clear();
                            ListaCompleta();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Informe o número do ID desejado: ");
                            int id = int.Parse(Console.ReadLine());
                            ListaParcial(id);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Programa Encerrado, pressione ENTER para fechar a tela !");
                            Console.ReadLine();
                            encerrarPrograma = true;
                            break;
                    }

                }
                else 
                {
                    Console.WriteLine("Opção escolhida é inválida, favor digitar a numerção indicada");
                    Console.ReadLine();

                }
            }
        }

        static void ListaCompleta()
        {
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos");
            requisicao.Method = "GET";
            var resposta = requisicao.GetResponse();
            
            using (resposta)
            {
                var stream = resposta.GetResponseStream();
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();

                List<Tarefa> tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(dados.ToString());

                foreach (Tarefa tarefa in tarefas)
                {
                    tarefa.Exibir();
                }
                stream.Close();
                resposta.Close();

            }

            Console.ReadLine();
        }

        static void ListaParcial(int auxID)
        {
            var requisicao = WebRequest.Create($"https://jsonplaceholder.typicode.com/todos/{auxID}");
            requisicao.Method = "GET";
            var resposta = requisicao.GetResponse();
            using (resposta)
            {
                var stream = resposta.GetResponseStream();
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();

                Tarefa tarefa = JsonConvert.DeserializeObject<Tarefa>(dados.ToString());

                tarefa.Exibir();

                stream.Close();
                resposta.Close();

            }

            Console.ReadLine();
        }
    }
}
