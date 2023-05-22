using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using PizzaAppWpf.MVVM.Model;

#pragma warning disable
namespace PizzaAppWpf.DataBase;

partial class Database
{
    private ObservableCollection<DrinkModel> _drinksList = new();
    public ObservableCollection<DrinkModel> GetAllDrinks() => _drinksList;

    private void GetDrinksFromDb(SqlConnection connection)
    {
        // Get Drink Sizes
        List<CapacitiesModel> drinkSizes = new();
        try
        {
            connection.Open();
            SqlCommand drinksSizeCommand = new SqlCommand("SELECT * FROM Capacities", connection);
            SqlDataReader sizeReader = drinksSizeCommand.ExecuteReader();

            while (sizeReader.Read())
            {
                CapacitiesModel drinkSize = new()
                {
                    Id = (int)sizeReader["ID"],
                    Name = sizeReader["Name"].ToString(),
                    Price = (int)sizeReader["Price"]
                };
                drinkSizes.Add(drinkSize);
            }

            connection.Close();
        }
        catch (Exception e)
        {
            MessageBox.Show($"Error: {e.Message} \n Getting Drink Sizes From DB");
        }

        try
        {
            SqlCommand drinksCommand = new SqlCommand("SELECT * FROM dbo.Drinks", connection);
            connection.Open();
            SqlDataReader drinksReader = drinksCommand.ExecuteReader();


            // Get Drinks
            while (drinksReader.Read())
            {
                DrinkModel drink = new()
                {
                    imageUrl = drinksReader["imageUrl"].ToString(),
                    Name = drinksReader["Name"].ToString(),
                    Description = drinksReader["Description"].ToString(),
                    Size = drinkSizes
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