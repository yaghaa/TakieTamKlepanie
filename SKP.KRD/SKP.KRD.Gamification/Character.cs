using System.Collections.Generic;
using System.ComponentModel;

namespace SKP.KRD.Gamification
{
    public class Character
    {
        private string _name;
        private int _experienceKRD;
        private int _experienceOverall;
        public List<Skill> _skills; 

        [DisplayName("Nazwa")]
        public string Name
        {
            get { return _name; }
        }

        public int ExpKrd {
            get
            {
                return _experienceKRD;
            } 
        }


        public Character(CharacterModel parameters)
        {
            _name = parameters.Name;
            _experienceKRD = parameters.ExK;
            _experienceOverall = parameters.ExO;
            _skills = parameters.Skills;
        }

        public static List<Character> CharactersDefault()
        {
            
             return new List<Character>()
            {
                new Character(new CharacterModel("Name1", 3, 4, SkillsDefault())),
                new Character(new CharacterModel("Name2", 2, 4, SkillsDefault())),
                new Character(new CharacterModel("Name3", 10, 15, SkillsDefault())),
                new Character(new CharacterModel("Name4", 1, 1, SkillsDefault())),
                
            };
        }

        public static List<Skill> SkillsDefault()
        {
            var temp = new List<Skill>()
            {
                new HardSkill("skill1", SkillValue.a),
                new HardSkill("skill2", SkillValue.a),
                new HardSkill("skill3", SkillValue.a),
            };

            return temp;
        } 

         
    }
}