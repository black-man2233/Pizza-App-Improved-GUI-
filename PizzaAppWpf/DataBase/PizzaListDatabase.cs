using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Channels;
using System.Windows;
using Newtonsoft.Json;
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

    private void addPizzasToDBFromJson(string jsonFilePath)
    {
        try
        {
            ObservableCollection<PizzaModel>? _pizzas =
                JsonConvert.DeserializeObject<ObservableCollection<PizzaModel>>(
                    File.ReadAllText($@"{jsonFilePath}"));
        }
        catch (Exception e)
        {
            MessageBox.Show("Couldn't read data from the given file");
        }

        try
        {
            string connectionString =
                @"Data Source = SIMPORD\SQLEXPRESS; Initial Catalog=PizzaApp; Integrated Security=True;";


            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Iterate over each pizza in the _pizzas collection
                foreach (PizzaModel pizza in _pizzas)
                {
                    // Create a SQL command for inserting the pizza into the table
                    string sql = "INSERT INTO dbo.PizzasList (imageUrl, description, name, price) " +
                                 "VALUES (@ImageUrl, @Description, @Name, @Price)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Set the parameter values for the SQL command
                        command.Parameters.AddWithValue("@ImageUrl", pizza.imageUrl);
                        command.Parameters.AddWithValue("@Description", pizza.Description);
                        command.Parameters.AddWithValue("@Name", pizza.Name);
                        command.Parameters.AddWithValue("@Price", pizza.Price);

                        // Execute the SQL command
                        command.ExecuteNonQuery();
                    }
                }
            }

            System.Console.WriteLine("Yay", Console.ForegroundColor = ConsoleColor.Green);
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine($"Ohh No \n{e.Message} ", Console.ForegroundColor = ConsoleColor.Red);
        }
    }
}