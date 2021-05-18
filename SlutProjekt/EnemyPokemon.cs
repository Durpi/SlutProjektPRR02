using System;
using System.Threading;

namespace SlutProjekt
{
    public class EnemyPokemon: Pokemon
    {
        
        //
        public void Fight(string userPokemonName, int userPokemonWeight, int userPokemonHeight, int userPokemonBaseExperience,
                        string enemyPokemonName, int enemyPokemonWeight, int enemyPokemonHeight, int enemyPokemonBaseExperience)
        {

            int userPoint = 0;

            if (enemyPokemonWeight > userPokemonWeight)
            {
                Console.WriteLine("The " + enemyPokemonName + " tried to jump and crush your " + userPokemonName);
                
                if (enemyPokemonHeight > userPokemonHeight)
                {
                    Console.WriteLine("The " + enemyPokemonName + " successfully crushed your " + userPokemonName);
                }
                else
                {
                    Console.WriteLine("The " + enemyPokemonName + " wasn't tall enought to jump on top of your " + userPokemonName + 
                    "\nso your " + userPokemonName + " pushed the " + enemyPokemonName + " over and it couldn't get up");
                    userPoint++;
                }
            }
            else if (userPokemonWeight > enemyPokemonWeight)
            {
                Console.WriteLine("Your " + userPokemonName + " tried to jump and crush the " + enemyPokemonName);
                
            }

            
        }

    }
}
