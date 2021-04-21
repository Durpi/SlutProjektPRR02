using System;
using System.Threading;

namespace SlutProjekt
{
    public class EnemyPokemon: Pokemon
    {
        
        public void Fight(string userPokemonName, int userPokemonWeight, int userPokemonHeight, int userPokemonBaseExperience,
                        string enemyPokemonName, int enemyPokemonWeight, int enemyPokemonHeight, int enemyPokemonBaseExperience)
        {

            if (userPokemonWeight < enemyPokemonWeight)
            {
                Console.WriteLine("The " + enemyPokemonName + " tried to jump and crush your " + userPokemonName);
            }
            else if (userPokemonWeight > enemyPokemonWeight)
            {
                Console.WriteLine("Your " + userPokemonName + " tried to jump and crush the " + enemyPokemonName);
            }

            Thread.Sleep(3000);

            if (userPokemonHeight < enemyPokemonHeight)
            {
                
            }
            else if (userPokemonHeight > enemyPokemonHeight)
            {
                
            }

        }

    }
}
