using System.Collections.Generic;

namespace SKP.KRD.Gamification
{
    public class CharacterParameters
    {
        public string Name { get; set; } 
        public int ExK { get; set; } 
        public int ExO { get; set; } 
        public List<Skill> Skills { get; set; }

        public CharacterParameters(string name, int exK, int exO, List<Skill> list)
        {
            Name = name;
            ExK = exK;
            ExO = exO;
            Skills = list;
        }
        
    }
}