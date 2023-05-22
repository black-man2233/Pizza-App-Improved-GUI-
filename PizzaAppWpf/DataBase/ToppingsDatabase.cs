using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using PizzaAppWpf.Model;
using PizzaAppWpf.MVVM.Model;

#pragma warning disable
namespace PizzaAppWpf.DataBase;

public partial class Database
{
    private ObservableCollection<ToppingsModel> _toppings = new ObservableCollection<ToppingsModel>();

    public ObservableCollection<ToppingsModel> GetToppings() => _toppings;

    private void GetToppingsFromDb(SqlConnection connection)
    {
        try
        {
            if (connection is null)
                return;

            SqlCommand command = new SqlCommand("SELECT * FROM dbo.Toppings", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ToppingsModel topping = new()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetInt32(2)
                };

                _toppings.Add(topping);
            }
        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message);
        }
        finally
        {
            connection.Close();
        }
    }
}