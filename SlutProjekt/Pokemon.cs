using System;
using Newtonsoft.Json;

namespace SlutProjekt
{
    public class Pokemon
    {
        //These are for storing all values that I want when sending the request to the PokeAPI database
        public string Name {get; set;}

        public int Weight {get; set;}

        //BaseExperience is read as base_experience by Json
        [JsonProperty("base_experience")]
        public int BaseExperience {get; set;}

        public int Height {get; set;}
    }
}
