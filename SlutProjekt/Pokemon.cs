using System;
using Newtonsoft.Json;

namespace SlutProjekt
{
    public class Pokemon
    {
        public string Name {get; set;}

        public int Weight {get; set;}

        [JsonProperty("base_experience")]
        public int BaseExperience {get; set;}

        public int Height {get; set;}
    }
}
