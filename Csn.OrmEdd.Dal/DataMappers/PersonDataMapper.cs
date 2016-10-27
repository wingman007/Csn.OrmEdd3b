namespace Csn.OrmEdd3b.Dal.DataMappers
{
    using Csn.OrmEdd3b.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    public class PersonDataMapper : IDataMapper<Person>
    {
        private readonly string _file;

        public PersonDataMapper()
        {
            _file = "Person.csv";
        }

        public PersonDataMapper(string file)
        {
            _file = file;
        }

        public int GetNextId()
        {
            int id  = 0;
            try
            {
                StreamReader reader = new StreamReader(_file); // UTF-8
                using (reader)
                {
                    string line = reader.ReadLine();
                    string[] lineElements = new string[] {"","","","",""};
                    char[] separator = new char[]{','};
                    while (line != null)
                    {
                        lineElements = line.Split(separator);
                        line = reader.ReadLine();
                    }

                    id = int.Parse(lineElements[0]);     
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("File not found!");
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("Io exception {0}", e.Message);
            }
            return id + 1;
        }

        public Person Get(int id)
        {
            Person person = new Person();
            try
            {
                StreamReader reader = new StreamReader(_file); // UTF-8
                using (reader)
                {
                    string line = reader.ReadLine();
                    string[] lineElements = new string[5]; // { "", "", "", "", "" };
                    char[] separator = new char[] { ',' };
                    while (line != null)
                    { 
                        lineElements = line.Split(separator);
                        person.Id = int.Parse(lineElements[0]);
                        person.Name = lineElements[1];
                        person.FamilyName = lineElements[2];
                        person.BirthDate = DateTime.Parse(lineElements[3]);
                        person.Address = lineElements[4];
                        if (int.Parse(lineElements[0]) == id) break;
                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("File not found!");
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("Io exception {0}", e.Message);
            }
            return person;
        }

        public List<Person> GetAll()
        {
            List<Person> persons = new List<Person>();
            try
            {
                StreamReader reader = new StreamReader(_file); // UTF-8
                using (reader)
                {
                    string line = reader.ReadLine();
                    string[] lineElements = new string[5]; // { "", "", "", "", "" };
                    char[] separator = new char[] { ',' };
                    while (line != null)
                    {
                        Person person = new Person();
                        lineElements = line.Split(separator);
                        person.Id = int.Parse(lineElements[0]);
                        person.Name = lineElements[1];
                        person.FamilyName = lineElements[2];
                        person.BirthDate = DateTime.Parse(lineElements[3]);
                        person.Address = lineElements[4];
                        persons.Add(person);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("File not found!");
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("Io exception {0}", e.Message);
            }
            return persons;
        }


        public void Insert(Person person)
        {
            if (person.Id == 0) person.Id = GetNextId(); 
            try
            {
                StreamWriter writer = new StreamWriter(_file, true); // UTF-8
                using (writer)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4}", 
                        person.Id,
                        person.Name,
                        person.FamilyName,
                        person.BirthDate.ToString("yyyy-MM-dd"),
                        person.Address);
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("Io exception {0}", e.Message);
            }
        }

        public void Update(Person person)
        {
            List<Person> persons = GetAll();
            for (int i = 0; i < persons.Count(); i++)
            {
                if (persons[i].Id == person.Id)
                {
                    persons[i] = person;
                    break;
                }
                    
            }
            SaveAll(persons);
        }

        public void Delete(int id)
        {
            List<Person> persons = GetAll();
            for (int i = 0; i < persons.Count(); i++)
            {
                if (persons[i].Id == id)
                {
                    persons.RemoveAt(i);
                    break;
                }
            }

            SaveAll(persons);
        }

        private void SaveAll(List<Person> persons)
        {
            try
            {
                StreamWriter writer = new StreamWriter(_file, false); // UTF-8
                using (writer)
                {
                    foreach (Person person in persons)
                    {
                        writer.WriteLine("{0},{1},{2},{3},{4}",
                            person.Id,
                            person.Name,
                            person.FamilyName,
                            person.BirthDate.ToString("yyyy-MM-dd"),
                            person.Address);
                    }
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("Io exception {0}", e.Message);
            }
        }
    }
}
