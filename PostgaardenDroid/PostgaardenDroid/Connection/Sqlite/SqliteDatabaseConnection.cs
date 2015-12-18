using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace Postgaarden.Connection.Sqlite
{
    /*
        Developed by Chris Wohlert
    */
    
    public class SqliteDatabaseConnection : DatabaseConnection
    {        
        private static DatabaseConnection instance;
        private SqliteConnection sqlConnection;
        private bool isOpen;
        string pathToDatabase;



        public override void CreateDB()
        {           
            SqliteConnection.CreateFile(pathToDatabase);
        }

        /// <summary>
        /// Prevents a default instance of the SqliteDatabaseConnection class from being created.
        /// </summary>
        private SqliteDatabaseConnection(string sqliteFilePath)
        {
            pathToDatabase = sqliteFilePath;
            if (!File.Exists(pathToDatabase))
                CreateDB();
            //else
            //{
            //    CreateDB();
            //}            
            sqlConnection = new SqliteConnection("Data Source=" + sqliteFilePath + ";Version=3;");            
        }

        /// <summary>
        /// Opens this instance.
        /// </summary>
        protected override void Open()
        {
            if (!isOpen)
            {
                sqlConnection.Open ();
                isOpen = true;
            }
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        protected override void Close()
        {
            if (isOpen)
            {
                sqlConnection.Close();
                isOpen = false;
            }
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public override IEnumerable<IEnumerable<object>> ExecuteQuery(string sql)
        {
            Open();

            var command = new SqliteCommand(sql, sqlConnection);
            var reader = command.ExecuteReader();
            var sqlReturn = Read(reader).ToList();

            Close();

            return sqlReturn;
        }

        /// <summary>
        /// Reads the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private IEnumerable<IEnumerable<object>> Read(SqliteDataReader reader)
        {
            while (reader.Read())
            {
                var row = new object[reader.FieldCount];
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = reader.GetValue(i);
                    if (reader.IsDBNull(i))
                        row[i] = "";
                }
                yield return row;
            }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static DatabaseConnection GetInstance(string sqliteFilePath)
        {
            if (instance == null) instance = new SqliteDatabaseConnection(sqliteFilePath);
            return instance;
        }
        public override void CreateTable(string sql)
        {
            ExecuteQuery(sql);
        }
    }
}
