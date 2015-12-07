using System.Collections.Generic;

namespace SKP.KRD.Gamification
{
    public class Character
    {
        private string _name;
        private int _experienceKRD;
        private int _experienceOverall;
        private List<Skill> _skills; 

        public string Name
        {
            get { return _name; }
        }


        public Character(CharacterModel parameters)
        {
            
            var character = new CharacterModel()
            {
                ExK = 0,
                ExO = 0,
                Name = "cos",
                Skills = new List<Skill>() { new HardSkill("mvc", SkillValue.a), new HardSkill("wpf", (SkillValue)1) }
            };
        }

         
    }
}