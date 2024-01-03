using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ahmad_154538_C8
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Initailizing the Max Qouta of the order management system
            OrderManagementSystem OrderQouta = new OrderManagementSystem(20);
            //giving the reading file path
            string ReadPath = @"F:\Products.txt";
            //Calling the Reading method
            OrderManagementSystem.Read(ReadPath);
            //giving the write file path
            string WritePath = @"F:\report.txt";
            //calling the Printing method
            OrderManagementSystem.Printing(OrderManagementSystem.Read(ReadPath), WritePath);
        }
    }
}
