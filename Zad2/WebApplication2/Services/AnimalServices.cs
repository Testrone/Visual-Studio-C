using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class AnimalServices
    {
        public interface IDatabaseService
        {
            IEnumerable<Animal> GetAnimals(string ordered);
            Animal AddAnimals(Animal animal);
            Animal UpdateAnimals(Animal animal, int idAnimal);
            void DeleteAnimals(int idAnimal);
            bool animalExists(int idAnimal);
        }

        public class DataBaseService : IDatabaseService
        {
            private IConfiguration _configuration;

            public DataBaseService(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public IEnumerable<Animal> GetAnimals(string ordered)
            {
                List<Animal> animals = new List<Animal>();
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ConnectionStrings")))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    con.Open();
                    if (string.IsNullOrEmpty(ordered))
                    {
                        com.CommandText = "Select * from Animal ORDER BY NAME ASC";
                    }
                    else if (ordered == "name" || ordered == "description" || ordered == "category" || ordered == "area")
                    {
                        com.CommandText = "Select * from Animal ORDER BY " + ordered;
                    }
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        Animal animal = new Animal
                        {
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString(),
                            Category = dr["Category"].ToString(),
                            Area = dr["Area"].ToString()
                        };
                        animals.Add(animal);
                    }
                }
                return animals;
            }

            public Animal AddAnimals(Animal animal)
            {
                throw new System.NotImplementedException();
            }

            public Animal UpdateAnimals(Animal animal, int idAnimal)
            {
                throw new System.NotImplementedException();
            }

            public void DeleteAnimals(int idAnimal)
            {
                throw new System.NotImplementedException();
            }

            public bool animalExists(int idAnimal)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
