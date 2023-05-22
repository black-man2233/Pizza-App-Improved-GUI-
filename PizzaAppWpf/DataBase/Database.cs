using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows;

#pragma warning disable
namespace PizzaAppWpf.DataBase
{
#pragma warning disable
    public partial class Database
    {
        public static Database Instance { get; }

        static Database()
        {
            Instance = new Database();

            Instance.GetPizzasFromDb(Instance.GetConnection());
            Instance.GetToppingsFromDb(Instance.GetConnection());
            Instance.GetDrinksFromDB(Instance.GetConnection());
            Instance.GetCapacitiesFromDB(Instance.GetConnection());
        }

        private SqlConnection GetConnection()
        {
            string connectionString =
                @"Data Source = SIMPORD\SQLEXPRESS; Initial Catalog=PizzaApp; Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}