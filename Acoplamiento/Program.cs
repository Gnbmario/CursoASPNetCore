using System;
using System.Collections.Generic;

namespace Acoplamiento
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrdersRepository repository = new OrdersFromAPIRepository();

            var service = new OrdersService(repository);

            var pedidos = service.GetOrders();
            
            foreach (var pedido in pedidos)
            {
                Console.WriteLine(pedido);
            }
        }
    }


    public class OrdersService
    {
        IOrdersRepository _ordersRepository;
        public OrdersService(IOrdersRepository repository)
        {
            _ordersRepository= new OrdersRepository();
        }

        public List<string> GetOrders()
        {
            var orders = _ordersRepository.GetOrdersFromDB();
            return orders;
        }
    }


    public interface IOrdersRepository
    {
        List<string> GetOrdersFromDB();
    }

    public class OrdersRepository: IOrdersRepository
    {
        public List<string> GetOrdersFromDB()
        {
            var orders = new List<string>()
            {
                "Pedido 1",
                "Pedido 2",
                "Pedido 3",
            };
            return orders;
        }
    }

    public class OrdersFromAPIRepository : IOrdersRepository
    {
        public List<string> GetOrdersFromDB()
        {
            var orders= new List<string>()
            {
                "Pedido desde api 1",
                "Pedido desde api 2",
                "Pedido desde api 3",
            };
            return orders;
            // No da pedido desde api, habrá algo mal de ordersfromapi
        }
    }
}
