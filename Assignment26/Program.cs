using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee obj = new Employee()
            {
                ID = 1,
                FirstName = "Suresh",
                LastName = "Raina",
                Salary = 50000.00

            };
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\mphasis\assignments\Day21\Ass26\Assignment26\Assignment26\employee.bin", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, obj);
            stream.Close();

            stream = new FileStream(@"D:\mphasis\assignments\Day21\Ass26\Assignment26\Assignment26\employee.bin", FileMode.Open, FileAccess.Read);
            Employee empdata = (Employee)formatter.Deserialize(stream);
            Console.WriteLine( "ID:" +empdata.ID);
            Console.WriteLine("first Name :"+empdata.FirstName);
            Console.WriteLine("Last Name :"+empdata.LastName);
            Console.WriteLine("Salary :"+empdata.Salary);

            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter writer = new StreamWriter("employee.xml"))
            {
                serializer.Serialize(writer, obj);
            }
            // deserialize the object from xml
            using (TextReader reader = new StreamReader("employee.xml"))
            {
                Employee deserializedemployee = (Employee)serializer.Deserialize(reader);
                Console.WriteLine($"ID: {deserializedemployee.ID} , firstname: {deserializedemployee.FirstName}, LastName: {deserializedemployee.LastName}, Salary: {deserializedemployee.Salary} ");
            }
            Console.ReadKey();
        }
    }
}
