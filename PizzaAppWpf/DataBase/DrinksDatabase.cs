using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using PizzaAppWpf.MVVM.Model;

#pragma warning disable
namespace PizzaAppWpf.DataBase;

partial class Database
{
    private ObservableCollection<DrinkModel> _drinksList = new();

    private void GetDrinksFromDB(SqlConnection connection)
    {
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.Drinks", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DrinkModel drink = new()
                {
                    imageUrl = reader["imageUrl"].ToString(),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString()
                };
                _drinksList.Add(drink);
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Error: Getting Drinks From DB ");
        }
        finally
        {
            connection.Close();
        }
    }
}