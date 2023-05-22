using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using PizzaAppWpf.MVVM.Model;

namespace PizzaAppWpf.DataBase;

partial class Database
{
    private ObservableCollection<CapacitiesModel> _capacitiesList = new();
    public ObservableCollection<CapacitiesModel> GetAllCapacites() => _capacitiesList;

    private void GetCapacitiesFromDB(SqlConnection connection)
    {
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.Capacities", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                CapacitiesModel capacity = new()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetInt32(2)
                };
                
                _capacitiesList.Add(capacity);
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Error Capaities From DB");
        }
        finally
        {
            connection.Close();
        }
    }
}