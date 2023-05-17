using System.Collections.ObjectModel;
using System.Data.SqlClient;
using PizzaAppWpf.Model;
namespace PizzaAppWpf.DataBase;
#pragma warning disable

partial class Database
{
    //PizzaList
    private ObservableCollection<PizzaModel>? _pizzaList = new();

    private void GetPizzasFromDb(SqlConnection connection)
    {
        if (connection is null)
        {
            return;
        }

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

    public ObservableCollection<PizzaModel> GetAllPizzas() => this._pizzaList;
}