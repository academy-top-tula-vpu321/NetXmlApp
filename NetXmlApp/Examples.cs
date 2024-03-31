using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetXmlApp
{
    static class Examples
    {
        static void XmlSerializeExample()
        {
            Address moscow = new Address() { City = "Moscow", Street = "Tverskaya" };
            Address piter = new Address() { City = "St. Peterburg", Street = "Nevsky" };

            Company yandex = new Company() { Title = "Yandex", Address = moscow };
            Company piterSoft = new Company() { Title = "Piter Soft", Address = piter };
            Company ozon = new Company() { Title = "Ozon", Address = moscow };

            List<Employee> employees = new()
            {
                new()
                {
                    Name = "Bobby",
                    BirthDate = new(2001, 4, 21),
                    Company = yandex
                },
                new()
                {
                    Name = "Sammy",
                    BirthDate = new(1999, 11, 4),
                    Company = piterSoft
                },
                new()
                {
                    Name = "Jimmy",
                    BirthDate = new(1989, 7, 16),
                    Company = yandex
                },
                new()
                {
                    Name = "Tommy",
                    BirthDate = new(2000, 6, 11),
                    Company = piterSoft
                },
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));

            using (FileStream stream = new FileStream("employees.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(stream, employees);
            }
        }
    }


    public class Address
    {
        public string City { get; set; } = "";
        public string Street { get; set; } = "";
    }

    public class Company
    {
        public string Title { set; get; } = "";
        public Address? Address { get; set; }
    }

    public class Employee
    {
        public string Name { set; get; } = "";
        public DateTime BirthDate { get; set; }
        public Company? Company { get; set; }
    }
}


