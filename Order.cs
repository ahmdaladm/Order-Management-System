using ahmad_154538_C8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ahmad_154538_C8
{
    //Class Customer That Has Only Constractor To get the data from the read method in Class OrderManagementSystem and Inhert it to Class Order
    public class Customer
    {
        public int OrderID;
        public string ProductName;
        public double Qty;
        public string AdditionalDetails;
        public string OrderStatus;
        public double Price;
        protected string CustomerName;
        public Customer(int OrderID, string ProductName, double Qty, string AdditionalDetails, string OrderStatus, double Price, string CustomerName)
        {
            this.OrderID = OrderID;
            this.ProductName = ProductName;
            this.Qty = Qty;
            this.AdditionalDetails = AdditionalDetails;
            this.OrderStatus = OrderStatus;
            this.Price = Price;
            this.CustomerName = CustomerName;
        }
    }
    //Class Order Which Inhert From Class Customer 
    public class Order : Customer
    {
        //inherting Class Customer to the constractor of Class Order
        public Order(int OrderID, string ProductName, double Qty, string AdditionalDetails, string OrderStatus, double Price, string CustomerName)
        : base(OrderID, ProductName, Qty, AdditionalDetails, OrderStatus, Price, CustomerName)
        {
            this.OrderID = OrderID;
            this.ProductName = ProductName;
            this.Qty = Qty;
            this.AdditionalDetails = AdditionalDetails;
            this.OrderStatus = OrderStatus;
            this.Price = Price;
            this.CustomerName = CustomerName;
        }
        //static method to calculate the most and least Ordered Products 
        public static Order[] MostAndLeastOrder(Order[] orders)
        {
            //object form class as most ordered product
            Order mostOrdered = orders[0];
            //for cicle that will run thru the orders (in range of the max qouta) and count only the highest Quantity of the orders
            for (int i = 1; i < OrderManagementSystem.max_order; i++)
            {
                //logic of most ordered
                if (orders[i].Qty > mostOrdered.Qty)
                {
                    mostOrdered = orders[i];
                }
            }
            //object form class as least ordered product 
            Order leastOrdered = orders[0];
            //for cicle that will run thru the orders (in range of the max qouta) and count only the Lowest Quantity of the orders
            for (int i = 1; i < OrderManagementSystem.max_order; i++)
            {
                //logic of least ordered
                if (orders[i].Qty < leastOrdered.Qty)
                {
                    leastOrdered = orders[i];
                }
            }
            //returning two objects only one stores the least ordered and the other one stores the most
            return new Order[] { mostOrdered, leastOrdered };
        }
        //static method of calculating the rejected orders that extended the max qouta
        public static Order[] RejectedOrders(Order[] orders)
        {
            //initializing the max qouta
            int max = OrderManagementSystem.max_order;
            int length = orders.Length - max;
            //logic if the max qouta matched the orders to return empty array
            if (length <= 0)
            {
                return new Order[0];
            }
            //creating rejectedorders array that will store all information about the rejected orders inorder to print them 
            Order[] rejectedOrders = new Order[length];
            int rejectedIndex = 0;
            //for cicle to store the orders info into the rejectedorders array
            for (int i = max; i < orders.Length; i++)
            {
                rejectedOrders[rejectedIndex] = orders[i];
                rejectedIndex++;
            }
            //returning the array to Class Object
            return rejectedOrders;
        }
    }
    
}
