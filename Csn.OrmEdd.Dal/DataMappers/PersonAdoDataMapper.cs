using Csn.OrmEdd3b.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd3b.Dal.DataMappers
{
    public class PersonAdoDataMapper : IDataMapper<Person>
    {
        // Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\fmi\Documents\Visual Studio 2013\Projects\Csn.OrmEdd3b\Csn.OrmEdd3b.Console\App_Data\CsnOrmEdd3b.mdb";Persist Security Info=True
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
            Person person = new Person();
            using (_connection)
            {
                IDbCommand command = _connection.CreateCommand();
                command.Connection = _connection;
                command.CommandText = @"SELECT * FROM [Persons] WHERE [Id] = @id";
                IDataParameter param = command.CreateParameter();
                param.ParameterName = "@id";
                param.Value = id;
                command.Parameters.Add(param);

                _connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    person = Hydrate(reader);
                }
            }
            return person;            
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
                        Hydrate(reader);
                    } 
                }
            }
            return persons;
        }

        private Person Hydrate(IDataReader reader)
        {
            Person person = new Person();
            person.Id = (int)reader["Id"];
            person.Name = (string)reader["FirstName"];
            person.FamilyName = (string)reader["FamilyName"];
            person.BirthDate = DateTime.Parse((string)reader["BirthDate"]);
            person.Address = (string)reader["Address"];
            return person;
        }

        public void Insert(Person person)
        {
            using(_connection)
            {
                try
                {
                    IDbCommand command = _connection.CreateCommand();
                    command.Connection = _connection;
                    command.CommandText = @"INSERT INTO [Persons] 
                            ([FirstName],[FamilyName],[BirthDate],[Address]) VALUES 
                            (@Name, @FamilyName, @BirthDate,@Address)";
                    Extract(person, command);
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {       
                    throw e;
                }
            }
        }

        private void Extract(Person person, IDbCommand command)
        {
            IDataParameter param = command.CreateParameter();
            //param.ParameterName = "@Id";
            //param.Value = person.Id;
            //command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = person.Name;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@FamilyName";
            param.Value = person.FamilyName;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Birthdate";
            param.Value = person.BirthDate;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Address";
            param.Value = person.Address;
            command.Parameters.Add(param);
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
