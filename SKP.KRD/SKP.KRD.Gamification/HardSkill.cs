namespace SKP.KRD.Gamification
{
    public class HardSkill : Skill
    {
        public HardSkill(string name, SkillValue value)
        {
            this.Name = name;
            this.Value = value;
        }

        public HardSkill(string name)
        {
            this.Name = name;
        }
    }
}