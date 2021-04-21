using System;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SlutProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            
            List<string> enemyPokemonName = new List<string>() {"venusaur", "charizard", "blastoise", "butterfree", "beedrill", "pidgeot", "raticate"}; 

            int randomEnemyPokemonName = generator.Next(enemyPokemonName.Count);

            RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon/"); //API

            RestRequest requestForEnemy = new RestRequest(enemyPokemonName[randomEnemyPokemonName]);
            IRestResponse responseForEnemy = client.Get(requestForEnemy);

            Console.WriteLine("Please write a pokemon's name and check if they exist in this game"); //API
            string userPokemonName = Console.ReadLine().ToLower(); //API
            Console.Clear(); //API

            RestRequest requestForUser = new RestRequest(userPokemonName); //API
            IRestResponse responseForUser = client.Get(requestForUser); //API

            while (responseForUser.StatusCode == System.Net.HttpStatusCode.NotFound) //API
            {
                Console.WriteLine("That pokemon does not exist in this game." +
                "Please write a pokemon's name and check if they exist in this game");

                userPokemonName = Console.ReadLine().ToLower();
                Console.Clear();

                requestForUser = new RestRequest(userPokemonName);
                responseForUser = client.Get(requestForUser);
            }

            //För om allt ska vara i en while loop
            enemyPokemonName.Add(userPokemonName);

            EnemyPokemon enemyPokemon = JsonConvert.DeserializeObject<EnemyPokemon>(responseForEnemy.Content);

            Pokemon userPokemon = JsonConvert.DeserializeObject<Pokemon>(responseForUser.Content); //API

            // Console.WriteLine("Name: " + pokemon.Name); //API
            // Console.WriteLine("Base experience: " + pokemon.BaseExperience); //API
            // Console.WriteLine("Weight: " + pokemon.Weight); //API
            // Console.WriteLine("Height: " + pokemon.Height); //API

            // Console.WriteLine("\nName: " + enemyPokemon.Name);
            // Console.WriteLine("Base experience: " + enemyPokemon.BaseExperience);
            // Console.WriteLine("Weight: " + enemyPokemon.Weight);
            // Console.WriteLine("Height: " + enemyPokemon.Height);

            enemyPokemon.Fight(userPokemon.Name, userPokemon.Weight, userPokemon.Height, userPokemon.BaseExperience,
                                enemyPokemon.Name, enemyPokemon.Weight, enemyPokemon.Height, enemyPokemon.BaseExperience);

            Console.ReadLine();
        }
    }
}
