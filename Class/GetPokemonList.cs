using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Newtonsoft.Json;
using PokemonPartyConsoleApp.Class;
using PokemonPartyConsoleApp.Result;

namespace PokemonPartyConsoleApp.Class
{
    class GetPokemonList
    {
        public GetPokemonList()
        {

        }
        public GetListPokemonResult GetPokemonListByType(string pokemonTypeList)
        {
            GetListPokemonResult returnValue = new GetListPokemonResult();

            try
            {

                string method = @"type/";
                string url = ConfigurationManager.AppSettings["pokeApi"] + method;

                JsonSerializerSettings microsoftDateFormatHandling = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };

                string jsonRaw = JsonConvert.SerializeObject(pokemonTypeList, microsoftDateFormatHandling);
                byte[] jsonRequest = Encoding.UTF8.GetBytes(jsonRaw);
                byte[] jsonResult = SystemUtility.JsonHttpGetByte(jsonRequest, url + pokemonTypeList);
                string jsonResRaw = Encoding.UTF8.GetString(jsonResult);

                returnValue = JsonConvert.DeserializeObject<GetListPokemonResult>(jsonResRaw);
            }
            catch(Exception)
            {
            }
            
            return returnValue;

        }
    }
}
