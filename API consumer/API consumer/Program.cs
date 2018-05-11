using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace API_consumer
{

    class Program
    {

        public static IConfiguration Configuration { get; set; }
        static HttpClient client = new HttpClient();
        private static TodoList newList;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            Console.WriteLine(Configuration["applicationName"]);

            Console.ReadKey();

            RunAsync().GetAwaiter().GetResult();

            Console.ReadKey();

        }

        static async Task RunAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://loaclhost:51439/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var todoApi = "api/todo";

            var lists = GetTodoListsAsync(todoApi);

            var newlist = new TodoList()
            {
                Name = "Lista creada desde cliente",
                Owner = "Antonio"
            };

            var uri = await CreateTodoListAsync(newList, todoApi)
            Console.WriteLine(uri);
            Console.ReadKey()

        }
        

        private static async Task<Uri>CreateTodoListAsync(TodoList list, string uri)
        {
            var dataString = JsonConvert.SerializeObject(list);
            var content = new StringContent(dataString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;

        }

        private static async Task<List<TodoList>> GetTodoListsAsync(string path)
        {
            string result = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {

                result = await response.Content.ReadAsStringAsync();
            }

            var a = JsonConvert.DeserializeObject<List<TodoList>>(result);
            
            return a;
        }
    }
}
    