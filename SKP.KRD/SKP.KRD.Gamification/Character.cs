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

        public int KrdExperience {
            get
            {
                return _experienceKRD;
            } 
        }

        public int GeneralExperience
        {
            get
            {
                return _experienceOverall;
            }
        }

        public List<Skill> Skills
        {
            get
            {
                return _skills;
            }
        }

        public Character(CharacterParameters parameters)
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
                new Character(new CharacterParameters("Name1", 3, 4, DefaultSkills())),
                new Character(new CharacterParameters("Name2", 2, 4, DefaultSkills())),
                new Character(new CharacterParameters("Name3", 10, 15, DefaultSkills())),
                new Character(new CharacterParameters("Name4", 1, 1, DefaultSkills())),
                
            };
        }

        public static List<Skill> DefaultSkills()
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