using System;
using System.Text;
using System.Collections.Generic;
using Course.Entities.Enums;
using System.Globalization;

namespace Course.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; } = new Client();
        public List<OrderItem> OrderItens { get; set; } = new List<OrderItem>();

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem Item)
        {
            OrderItens.Add(Item);
        }

        public void RemoveItem(OrderItem Item)
        {
            OrderItens.Remove(Item);
        }

        public double Total()
        {
            double sum = 0;

            foreach (OrderItem item in OrderItens)
            {
                sum += item.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Order moment: ");
            stringBuilder.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            stringBuilder.Append("Order status: ");
            stringBuilder.AppendLine(Status.ToString());
            stringBuilder.Append("Client: ");
            stringBuilder.AppendLine(Client.ToString());
            stringBuilder.AppendLine("Order items:");
            foreach (OrderItem item in OrderItens)
            {
                stringBuilder.AppendLine(item.ToString());
            }
            stringBuilder.Append("Total price: $");
            stringBuilder.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));
           
            return stringBuilder.ToString();
        }

    }
}
