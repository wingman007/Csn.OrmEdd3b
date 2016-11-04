namespace Csn.OrmEdd3b.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Csn.OrmEdd3b.Models;
    using Csn.OrmEdd3b.Dal.DataMappers;
    using System.Globalization;
    using Csn.OrmEdd3b.Services;
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Please make your choice:");
                Console.WriteLine("1. List all items");
                Console.WriteLine("2. Insert");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Exit");
                int.TryParse(Console.ReadLine(), out choice);
                // dispatcher
                switch (choice)
                {
                    case 1 :
                        List();
                        break;
                    case 2:
                        Insert();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;
                }
            }while(choice != 5);

            /*
            Person person1 = new Person() 
            { 
                Name ="Stoyan",
                FamilyName = "Cheresharov",
                BirthDate = Convert.ToDateTime("1964-03-29"),
                Address = "Chem 7"
            };


            PersonRepository dalPerson = new PersonRepository();
            // dalPerson.Save(person1);

            Console.WriteLine("Name: {0}", person1.Name);

            Console.WriteLine("{0}", dalPerson.GetNextId());

            List<Person> persons = dalPerson.GetAll();
            foreach (Person person in persons)
            {
                Console.WriteLine("Id: {0}, Name: {1}", person.Id, person.Name);
            }

            Person person2 = dalPerson.Get(3);

            Console.WriteLine("The Id and Name of person 3 are: {0}, {1}", person2.Id, person2.Name);
            */
        }

        static void List()
        {
            // View
            Console.Clear();
            
            // Controller
            // IDataMapper<Person> dalPerson = new PersonFileDataMapper();
            // List<Person> persons = dalPerson.GetAll();
            IPersonServices personServices = new PersonServices();
            List<Person> persons = personServices.GetAll();
            
            // View
            foreach (Person person in persons)
            {
                //Console.WriteLine("Id: {0}, Name: {1}", person.Id, person.Name);
                Console.WriteLine(person);
            }

            // View
            Console.WriteLine("Press any kay to go back");
            Console.ReadLine();
        }

        static void Insert()
        {
            // Controller
            Person person = new Person();

            // view
            Console.Clear();
            Console.Write("Please enter Name: ");
            person.Name = Console.ReadLine();
            Console.Write("Family Name: ");
            person.FamilyName = Console.ReadLine();
            Console.Write("Birthdate (yyyy-MM-dd): ");
            CultureInfo provider = CultureInfo.InvariantCulture;
            // provider = new CultureInfo("fr-FR");
            person.BirthDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", provider);
            Console.Write("Address: ");
            person.Address = Console.ReadLine();

            // controller
            IDataMapper<Person> dalPerson = new PersonFileDataMapper();
            dalPerson.Insert(person);
        }

        static void Update()
        {
            // view
            int id = 0;

            do{
                Console.Clear();
                Console.Write("Please eneter the Id of a person to Update: ");
            }while(!int.TryParse(Console.ReadLine(), out id));

            IDataMapper<Person> dalPerson = new PersonFileDataMapper();
            Person person = dalPerson.Get(id);

            Console.Write("Please enter Name ({0}): ", person.Name);
            person.Name = Console.ReadLine();
            Console.Write("Family Name ({0}): ", person.FamilyName);
            person.FamilyName = Console.ReadLine();
            Console.Write("Birthdate ({0}): ", person.BirthDate.ToString("yyyy-MM-dd"));
            CultureInfo provider = CultureInfo.InvariantCulture;
            // provider = new CultureInfo("fr-FR");
            person.BirthDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", provider);
            Console.Write("Address ({0}): ", person.Address);
            person.Address = Console.ReadLine();

            // Controller
            dalPerson.Update(person);
        }

        static void Delete()
        {
            // view
            int id = 0;

            do
            {
                Console.Clear();
                Console.Write("Please eneter the Id of a person to Update: ");
            } while (!int.TryParse(Console.ReadLine(), out id));

            IDataMapper<Person> dalPerson = new PersonFileDataMapper();
            var person = dalPerson.Get(id);
            dalPerson.Delete(person);
        }
    }
}
