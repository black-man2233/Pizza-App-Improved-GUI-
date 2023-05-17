using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using PizzaAppWpf.Model;
using PizzaAppWpf.MVVM.Model;

namespace PizzaAppWpf.DataBase;
#pragma warning disable

partial class Database
{
    //PizzaList
    private ObservableCollection<PizzaModel>? _pizzaList = new();

    /// <summary>
    /// Get all pizzas from database
    /// </summary>
    /// <param name="connection"></param>
    private void GetPizzasFromDb(SqlConnection connection)
    {
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.PizzasList", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                PizzaModel pizza = new()
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Price = (int)reader["Price"],
                    Description = reader["Description"].ToString(),
                    imageUrl = reader["imageUrl"].ToString()
                };

                _pizzaList.Add(pizza);
            }
        }
        catch (Exception e)
        {
            //Shows a message in case of an error
            MessageBox.Show("Error in GetPizzasFromDb");
        }
    }

    public ObservableCollection<PizzaModel> GetAllPizzas() => this._pizzaList;
}