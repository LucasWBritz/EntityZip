using EntityZip;
using EntityZip.Reflection;
using EntityZipConsole.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace EntityZipConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            Person person = new Person()
            {
                Active = true,
                Email = "lucas@aaaabbb.com",
                FirstName = "Lucas",
                LastName = "Britz",
                Id = 1,
                Addresses = new List<Address>()
                {
                    new Address()
                    {
                        City = "Vancouver",
                        Country = "Canada",
                        MainAddress = true,
                        PostalCode = "UUyhhjYTT",
                        Street = "Something"
                    },
                    new Address()
                    {
                        City = "Vancouver",
                        Country = "Canada",
                        MainAddress = false,
                        PostalCode = "UUyhhjYTT2",
                        Street = "Something2"
                    }
                }
            };

            personList.Add(person);

            EntityZipConverter zip = new EntityZipConverter();
            zip.ConvertEntityToCSV(person, "Person");
            zip.ConvertListToCSV<Address>(person.Addresses, "Adresses");
            File.WriteAllBytes("MyData.zip", zip.ConvertToZipBytes());

            Console.ReadKey();
        }
    }
}
