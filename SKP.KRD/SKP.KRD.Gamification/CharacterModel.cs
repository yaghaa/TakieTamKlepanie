using System.Collections.Generic;

namespace SKP.KRD.Gamification
{
    public class CharacterModel
    {
        public string Name { get; set; } 
        public int ExK { get; set; } 
        public int ExO { get; set; } 
        public List<Skill> Skills { get; set; }

        
    }
}