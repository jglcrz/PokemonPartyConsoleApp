using PokemonPartyConsoleApp.Class;
using PokemonPartyConsoleApp.Result;
using PokemonPartyConsoleApp.Collection;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PokemonPartyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Please enter pokemon type (e.g.: flying, poison): ");
            string pokemonTypeInput = Console.ReadLine();
            Process(pokemonTypeInput);
            
            
        }
        static void Process(string pokemonTypeInput)
        {
            #region Initialization
            Random random = new Random();

            GetPokemonList getPokemonList = new GetPokemonList();
            GetListPokemonResult getPokemonListResult = new GetListPokemonResult();
            List<string> pokemonList = new List<string>();
            List<string> pokemonListFinal = new List<string>();

            int index;
            #endregion
            try
            {
                string[] pokemonType = pokemonTypeInput.Split(@", ");

                foreach (string type in pokemonType)
                {
                    
                    getPokemonListResult = getPokemonList.GetPokemonListByType(type);
                    if (getPokemonListResult.pokemon != null)
                    {
                        foreach (var pokemon in getPokemonListResult.pokemon)
                        {
                            pokemonList.Add(pokemon.pokemon.name);
                        }
                    }
                    
                }

                for (var i = 0; i < 5; i++)
                {
                    index = random.Next(pokemonList.Count);
                    pokemonListFinal.Add(pokemonList[index]);
                }

                for (var j = 0; j < pokemonListFinal.Count; j++)
                {
                    Console.WriteLine(pokemonListFinal[j]);

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("An unknown error has occured.");
                //log error here
            }
            
        }
    }
}
