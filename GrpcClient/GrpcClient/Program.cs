using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcClient.Protos;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int id = Convert.ToInt32(Console.ReadLine());
            var channel = GrpcChannel.ForAddress("https://localhost:8000");
            var client = new Category.CategoryClient(channel);
            var reply = client.GetCategory(new FindCategory { Id = id });
            Console.WriteLine($"Category: {reply.Id}, {reply.Name}");
        }
    }
}
