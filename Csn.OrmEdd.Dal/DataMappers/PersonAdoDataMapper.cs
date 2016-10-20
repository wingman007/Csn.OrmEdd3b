using Csn.OrmEdd.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd.Dal.DataMappers
{
    public class PersonAdoDataMapper : IDataMapper<Person>
    {
        // Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\fmi\Documents\Visual Studio 2013\Projects\Csn.OrmEdd3b\Csn.OrmEdd.Console\App_Data\CsnOrmEdd3b.mdb";Persist Security Info=True
        private readonly string _connectionString;

        private readonly IDbConnection _connection; 
        public PersonAdoDataMapper(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new OleDbConnection(_connectionString);
        }

        public PersonAdoDataMapper(IDbConnection connection)
        {
            _connection = connection;
        }

        public int GetNextId()
        {
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            // throw new NotImplementedException();
            List<Person> persons = new List<Person>();
            using(_connection)
            {
                IDbCommand command = _connection.CreateCommand();
                command.Connection = _connection;
                command.CommandText = @"SELECT * FROM [Persons]";
                _connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // persons.Add(Hydrate(reader));
                        // Person person = new Person();
                        // person.Id = (int)reader["Id"];

                    } 
                }
            }
            return persons;
        }


        public void Insert(Person person)
        {
            throw new NotImplementedException();
        }

        public void Update(Person person)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
