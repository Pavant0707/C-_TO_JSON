using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace C_ToJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
             CsharpToJson();
            JsonToC_();

        }

        private static Customer JsonToC_()
        {
            string fileNmae = @"C:\vs\cs.json";
            if (File.Exists(fileNmae))
            {
                string justText=File.ReadAllText(fileNmae);
                Customer c = Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(justText);
                return c;
            }
            return null;
        }

        static void CsharpToJson()
        {
            var c = CreateCustomer_v1();
            var jsonFormatedContent =Newtonsoft.Json.JsonConvert.SerializeObject(c);
            string file = @"C:\vs\cs.json";
            if (System.IO.File.Exists(file)==false)
            {
                System.IO.File.WriteAllText(file, jsonFormatedContent);
            }
            else
            {
                System.IO.File.Delete(file);
                System.IO.File.WriteAllText($"{file}", jsonFormatedContent);
            }
        }

        private static Customer CreateCustomer_v1()
        {
            var c = new Customer();
            c.customer_id = 10;
            c.customer_name = "sai";    
            c.employees = new List<Employee>();

            var e1=new Employee();
            e1.first_name = "sai";
            e1.last_name = "rama";
            c.employees.Add(e1);

            return c;
        }
        public class Customer
        {
            public int customer_id { get; set; }
            public string customer_name {  get; set; }
            public List<Employee> employees { get; set; }
        }
        public class Employee
        {
            public string first_name { get; set;}
            public string last_name { get; set;}
        }
    }

   
}
