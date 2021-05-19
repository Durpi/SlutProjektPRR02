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

            
            //Creates a random generator
            Random generator = new Random();

            //Creates a list for all the enemy pokemons that the user can face
            List<string> enemyPokemonName = new List<string>() { "venusaur", "charizard", "blastoise", "butterfree", "beedrill", "pidgeot", "raticate" };

            //Creates a que for all the enemy pokemon
            Queue<string> enemyPokemonQueue = new Queue<string>();

            //Randomly choses 3 pokemon from the list and adds them to the que
            enemyPokemonQueue.Enqueue(enemyPokemonName[generator.Next(enemyPokemonName.Count)]);
            enemyPokemonQueue.Enqueue(enemyPokemonName[generator.Next(enemyPokemonName.Count)]);
            enemyPokemonQueue.Enqueue(enemyPokemonName[generator.Next(enemyPokemonName.Count)]);

            //Creates a client that is going to send requests to PokeAPI
            //I added /pokemon/ so I only need to add the pokemon name for the request
            RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon/"); //API

            //Gets a pokemon from the user
            Console.WriteLine("Please write the name of a pokemon you want to use."); //API
            string userPokemonName = Console.ReadLine().ToLower(); //API
            Console.Clear(); //API

            //Sends the request to the PokeAPI database for https://pokeapi.co/api/v2/pokemon/ + whatever the user types
            //Then recives what the database sends back
            RestRequest requestForUser = new RestRequest(userPokemonName); //API
            IRestResponse responseForUser = client.Get(requestForUser); //API

            //It checks if the response accually sent something
            //If not it asks the user for a new pokemon until it recives a statuscode that is not NotFound, but OK which means that it recived data
            while (responseForUser.StatusCode == System.Net.HttpStatusCode.NotFound) //API
            {
                Console.WriteLine("That pokemon does not exist in this game." +
                "\nPlease write another pokemon that you want to use.");

                userPokemonName = Console.ReadLine().ToLower();
                Console.Clear();

                requestForUser = new RestRequest(userPokemonName);
                responseForUser = client.Get(requestForUser);
            }

            //Converts the data to the variables in the class Pokemon
            Pokemon userPokemon = JsonConvert.DeserializeObject<Pokemon>(responseForUser.Content); //API


            //It continues as long as there are things in the que
            while (enemyPokemonQueue.Count > 0)
            {
                //This uses the same client
                //This takes the first pokemon in the que and sends a request for it (I have checked that all pokemons in the list works)
                RestRequest requestForEnemy = new RestRequest(enemyPokemonQueue.Dequeue());
                IRestResponse responseForEnemy = client.Get(requestForEnemy);

                //Converts the data to the variables in the class EnemyPokemon
                EnemyPokemon enemyPokemon = JsonConvert.DeserializeObject<EnemyPokemon>(responseForEnemy.Content);

                
                //Starts the function Fight from the instance enemyPokemon
                //It takes in all the different data from both pokemons
                enemyPokemon.Fight(userPokemon.Name, userPokemon.Weight, userPokemon.Height, userPokemon.BaseExperience,
                                    enemyPokemon.Name, enemyPokemon.Weight, enemyPokemon.Height, enemyPokemon.BaseExperience);
            }


            Console.ReadLine();
        }
    }
}
