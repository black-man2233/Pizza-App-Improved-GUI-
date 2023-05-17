using System;
using Newtonsoft.Json;
using PizzaAppWpf.Model;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Windows;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public class Database
    {
        public static Database Instance { get; }

        static Database()
        {
            Instance = new Database();

            var a = GetConnection();
        }

        private static SqlConnection GetConnection()
        {
            const string connectionString =
                @"Data Source = .\SQLEXPRESS; Initial Catalog=PizzaApp; Integrated Security = true; Encrypt = False ";

            SqlConnection connection = new(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception e)
            {
              MessageBox.Show("Couldnt connect to database");
                return null;
            }
            
        }


        //PizzaList
        private ObservableCollection<PizzaModel> _pizzas = new();

        public ObservableCollection<PizzaModel> PizzaList
        {
            get => this._pizzas;
        }

        //Sides
        private ObservableCollection<SidesModel> _sides = new();

        public ObservableCollection<SidesModel> Sides
        {
            get => this._sides;
        }


        //Toppings
        private ObservableCollection<ToppingsListModel> _toppingsList = new();

        public ObservableCollection<ToppingsListModel> ToppingsList
        {
            get => _toppingsList;
        }

        //Extras
        private ObservableCollection<ExtrasModel> _extraList = new();

        public ObservableCollection<ExtrasModel> ExtrasList
        {
            get => _extraList;
        }
    }
}