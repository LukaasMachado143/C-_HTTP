using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP_HTTP
{
    internal class Tarefa
    {
        public int userId;
        public int id;
        public string title;
        public bool completed;

        public void Exibir()
        {
            Console.WriteLine("=========================================\n");
            Console.WriteLine($"userID: {userId}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"userID: {completed}");
            Console.WriteLine("\n=========================================");
        }
    }
}
