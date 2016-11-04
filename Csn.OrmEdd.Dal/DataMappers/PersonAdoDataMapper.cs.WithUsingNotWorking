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

        // ToDo concider removing this constructor
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

        public List<Person> GetAll()
        {
            List<Person> persons = new List<Person>();
            using (_connection)
            {
                try
                {
                    #region Preparation can be outside of try
                    IDbCommand command = _connection.CreateCommand();
                    command.Connection = _connection;
                    command.CommandText = @"SELECT * FROM [Persons]";
                    #endregion

                    _connection.Open();
                    //Perform DB operation here i.e. any CRUD operation 
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            persons.Add(Hydrate(reader));
                        }
                    }
                }
                catch (Exception e)
                {
                    // Log 
                    throw e;
                }
            }
            return persons;
        }

        public Person Get(object id) // int
        {
            Person person = new Person();
            using (_connection) // with using the conneciton is loosing the connection string for some strange reason on ns2 comp. SO I will use try catch. If more than 1 commands need to be executed I am loosing the connectionString in the conneciton object
            {
                try
                {
                    #region Preparation can be outside of try
                    IDbCommand command = _connection.CreateCommand();
                    command.Connection = _connection;
                    command.CommandText = @"SELECT * FROM [Persons] WHERE ID = @id";

                    IDataParameter param = command.CreateParameter();
                    param.ParameterName = "@id";
                    param.Value = (int)id;
                    command.Parameters.Add(param);
                    #endregion

                    _connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) person = Hydrate(reader);
                    }
                }
                catch (Exception e)
                {
                    // Log
                    throw e;
                }
//            finally
//            {
//                _connection.Close();
//            }
            }
            return person;
        }

        private Person Hydrate(IDataReader reader)
        {
            Person person = new Person();
            // It was working for GetAll with Id
            person.Id = (int)reader["ID"]; //  Id System.InvalidOperationException: No data exists for the row/column.
            person.Name = (string)reader["FirstName"];
            person.FamilyName = (string)reader["FamilyName"];
            // I don't need this System.InvalidCastException: Unable to cast object of type 'System.DateTime' to type 'System.String'.
            // person.BirthDate = DateTime.Parse((string)reader["BirthDate"]); // we don't need cast
            person.BirthDate = (DateTime)reader["BirthDate"]; // but we still need a cast
            person.Address = (string)reader["Address"];
            return person;
        }

        public void Insert(Person entity)
        {
            using (_connection)
            {
                try
                {
                    #region Can be outside try
                    IDbCommand command = _connection.CreateCommand();
                    command.Connection = _connection;
                    command.CommandText = @"INSERT INTO [Persons] 
                        ([FirstName],[FamilyName],[BirthDate],[Address]) VALUES 
                        (@Name,@FamilyName,@BirthDate,@Address)";
                    Extract(entity, command);
                    #endregion

                    _connection.Open();
                    //Perform DB operation here i.e. any CRUD operation 
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    // Log
                    throw e;
                }
            }
        }

        public void Update(Person entity)
        {
            using (_connection)
            {
                try
                {
                    #region Can be outside try
                    IDbCommand command = _connection.CreateCommand();
                    command.Connection = _connection;
                    // System.Data.OleDb.OleDbException: Cannot update 'ID'; field not updateable.  [ID]= @Id, 
                    command.CommandText = @"UPDATE [Persons] SET
                        [FirstName] = @Name,
                        [FamilyName] = @FamilyName,
                        [BirthDate] = @BirthDate,
                        [Address] = @Address 
                        WHERE ID = @Id";
                    Extract(entity, command);
                    // Set the Id also
                    IDataParameter param = command.CreateParameter();
                    param.ParameterName = "@Id";
                    param.Value = entity.Id;
                    command.Parameters.Add(param);
                    #endregion

                    _connection.Open();
                    //Perform DB operation here i.e. any CRUD operation 
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    // Log
                    throw e;
                }
            }
        }

        private void Extract(Person entity, IDbCommand command)
        {
            // When we insert we get             
            // Exception Details: System.Data.OleDb.OleDbException: Data type mismatch in criteria expression.
            // We have 2 options move the code to Update or use extra parameter in this function
            // IDataParameter param = command.CreateParameter();
            //param.ParameterName = "@Id";
            //param.Value = entity.Id;
            //command.Parameters.Add(param);

            IDataParameter param = command.CreateParameter();
            param = command.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = entity.Name;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@FamilyName";
            param.Value = entity.FamilyName;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@BirthDate";
            param.Value = entity.BirthDate;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Address";
            param.Value = entity.Address;
            command.Parameters.Add(param);
        }
        public void Delete(Person entity) // int
        {
            using (_connection)
            {
                try
                {
                    #region Can be outside try
                    IDbCommand command = _connection.CreateCommand();
                    command.Connection = _connection;
                    command.CommandText = @"DELETE FROM [Persons] WHERE ID = @Id";
                    IDataParameter param = command.CreateParameter();
                    param.ParameterName = "@Id";
                    param.Value = entity.Id;
                    command.Parameters.Add(param);
                    #endregion

                    // System.InvalidOperationException: The ConnectionString property has not been initialized.
                    _connection.Open();
                    //Perform DB operation here i.e. any CRUD operation 
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    // Log
                    throw e;
                }
            }
        }
    }
}
