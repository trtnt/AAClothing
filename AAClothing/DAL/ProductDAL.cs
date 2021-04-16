using AAClothing.Containers.Interfaces;
using AAClothing.DTO;
using AAClothing.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AAClothing.DAL
{
    public class ProductDAL: SQLBase, IProductDAL
    {
        private readonly string _connectionString = "Server=DESKTOP-JA9OFG0\\SQLEXPRESS;Database=AAClothing;Trusted_Connection=True;";

        public ProductDAL()
        {
            //Connection string oproepen vanuit SQLBase
        }

        //DTO update player 

        public List<ProductDTO> GetAll()
        {
            List<ProductDTO> ProductList = new List<ProductDTO>();
            try
            {
                string sql = "SELECT * FROM Product";

                DataSet results = ExecuteSql(sql, new List<KeyValuePair<string, string>>());

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    ProductDTO c = Parser.Parser.DataSetToProduct(results, x);
                    ProductList.Add(c);
                }
                return ProductList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ProductDTO GetByID(long id)
        {
            try
            {
                string sql = "SELECT * FROM Product WHERE Productid = @productid";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string,string>("@productid", id.ToString())
                };

                DataSet results = ExecuteSql(sql, parameters);
                ProductDTO c = Parser.Parser.DataSetToProduct(results, 0);
                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void insert(ProductDTO t)
        {
            try
            {
                string sql = "INSERT INTO Product (ProductId, Productnaam, Productbeshrijving, Productprijs, Productvoorraad) VALUES (@productid, @productnaam, @productbeschrijving, @productprijs, @productvoorraad)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("@productid", t.ProductId.ToString()),
                    new KeyValuePair<string, string>("@productnaam", t.ProductNaam.ToString()),
                    new KeyValuePair<string, string>("@productbeschrijving", t.ProductBeschrijving.ToString()),
                    new KeyValuePair<string, string>("@productprijs", t.ProductPrijs.ToString()),
                    new KeyValuePair<string, string>("@productvoorraad", t.ProductVoorraad.ToString()),
                };
                ExecuteInsert(sql, parameters);
            }
            catch
            {
                throw;
            }
        }

        public void update(ProductDTO product)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            string query = "UPDATE Product (Productnaam, Productprijs, Productbeschrijving, Productvoorraad) VALUES(@productnaam, @productprijs, @productbeschrijving, @productvoorraad) " +
                "WHERE Productnaam = '" + product.ProductNaam + "' AND Productbeschrijving = '" + product.ProductBeschrijving + "' " +
                "AND Productprijs '" + product.ProductPrijs + "' AND Productvoorraad '" + product.ProductVoorraad + "'";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@productnaam", product.ProductNaam);
            command.Parameters.AddWithValue("@productbeschrijving", product.ProductBeschrijving);
            command.Parameters.AddWithValue("@productprijs", product.ProductPrijs);
            command.Parameters.AddWithValue("@productvoorraad", product.ProductVoorraad);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
