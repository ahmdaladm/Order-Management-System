using ahmad_154538_C8;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ahmad_154538_C8
{
    public class OrderManagementSystem
    {
        //Property for the Max Qouta for the Order Management System 
        public static int max_order { get; set; }
        //Constractor to access max_order to set the max qouta of orders thru other methods 
        public OrderManagementSystem(int max_order)
        {
            OrderManagementSystem.max_order = max_order;
        }
        //Reading files static method with Class Array Order[]
        public static Order[] Read(string readpath)
        {
            //Try Cicle to read the file 
            try
            {
                //exracting the text from the file
                FileStream fs = new FileStream(readpath, FileMode.Open, FileAccess.Read);
            }
            //throwing error message if the file was not found 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Creating an array that takes each line as one index
            string[] OrderLine = File.ReadAllLines(readpath);
            //Cearting an array that will split the lines as data 
            Order[] FullRead = new Order[OrderLine.Length];
            //For cicle to cut lines with"," as each "," gives data
            for (int i = 0; i < OrderLine.Length; i++)
            {
                //array line that splits each line in OrderLine Array
                string[] line = OrderLine[i].Split(',');
                //storing the splited text as data
                FullRead[i] = new Order((i+1), line[0], double.Parse(line[1]), line[2], line[3], double.Parse(line[4]), line[5]);
            }
            //returning the Class Array to class Order Constracor As Data
            return FullRead;
        }
        //Printing Static non return method
        public static void Printing(Order[] order, string writepath)
        {
            double Revenue = 0;
            double Quantity = 0;
            //try block gives error if the path was wrong or unreachable
            try
            {
                //creating file in the drictory that is provided 
                FileStream fw = new FileStream(writepath, FileMode.Create, FileAccess.Write);
                //writing inside the file
                StreamWriter fs = new StreamWriter(fw);
                //Writing System Information 
                fs.WriteLine("Windows version: {0}", Environment.OSVersion);
                fs.WriteLine("64 Bit operating system? : {0}", Environment.Is64BitOperatingSystem ? "Yes" : "No");
                fs.WriteLine("PC Name : {0}", Environment.MachineName);
                fs.WriteLine("Number of CPUS : {0}", Environment.ProcessorCount);
                fs.WriteLine("Windows folder : {0}", Environment.SystemDirectory);
                fs.WriteLine("Logical Drives Available : {0}", String.Join(", ", Environment.GetLogicalDrives()).TrimEnd(',', ' ').Replace("\\", String.Empty));
                fs.WriteLine("-------------------------");
                //Printing the Orders Within the Qouta of the Order Managment System
                for (int i = 0; i < max_order; i++)
                {
                    Order product1 = order[i];
                    //calculating the Revenue of the Products 
                    Quantity += product1.Qty;
                    Revenue += product1.Price;
                    fs.WriteLine("OrderID:{0}\nProduct Name:{1}\nQuantity:{2}\nAdditional Details:{3}\nStatus:{4}", product1.OrderID, product1.ProductName, product1.Qty, product1.AdditionalDetails, product1.OrderStatus);
                    fs.WriteLine("-------------------------");
                }
                //printing total order and total revenue
                fs.WriteLine($"Total Quantity: {Quantity}");
                fs.WriteLine($"Total Revenue: {Revenue}");
                //Printing Least Ordered Product Within the Qouta 
                fs.WriteLine("-------------------------");
                //Cearitng Object
                Order[] mostAndLeast = Order.MostAndLeastOrder(order);
                //Printing Least Orrdered
                fs.WriteLine("\nLeast Ordered Product:\n");
                fs.WriteLine("OrderID:{0}\nProduct Name:{1}\nQuantity:{2}\nAdditional Details:{3}\nStatus:{4}", mostAndLeast[1].OrderID, mostAndLeast[1].ProductName, mostAndLeast[1].Qty, mostAndLeast[1].AdditionalDetails, mostAndLeast[1].OrderStatus);
                fs.WriteLine("-------------------------");
                //Printing Most Ordered
                fs.WriteLine("\nMost Ordered Product:\n");
                fs.WriteLine("OrderID:{0}\nProduct Name:{1}\nQuantity:{2}\nAdditional Details:{3}\nStatus:{4}", mostAndLeast[0].OrderID, mostAndLeast[0].ProductName, mostAndLeast[0].Qty, mostAndLeast[0].AdditionalDetails, mostAndLeast[0].OrderStatus);
                fs.WriteLine("-------------------------");
                //Printing Rejected Ordered Products That Extended the Max Qouta 
                Order[] rejectedorders = Order.RejectedOrders(order);
                //Logic If that will Print how many orders were rejected only if there was any rejected orders only
                if (rejectedorders.Length > 0)
                {
                    fs.WriteLine("There is {0} Rejected Orders", rejectedorders.Length);
                    fs.WriteLine("-------------------------");
                }
                //for cicle which will Print the rejected orders 
                for (int i = 0; i < rejectedorders.Length; i++)
                {
                    fs.WriteLine("OrderID:{0}\nProduct Name:{1}\nQuantity:{2}\nAdditional Details:{3}\nStatus:{4}", rejectedorders[i].OrderID, rejectedorders[i].ProductName, rejectedorders[i].Qty, rejectedorders[i].AdditionalDetails, rejectedorders[i].OrderStatus);
                    fs.WriteLine("-------------------------");
                }
                //closing the file 
                fs.Close();
            } catch (Exception ex) { Console.WriteLine( ex.Message); }
        }
    }
}

