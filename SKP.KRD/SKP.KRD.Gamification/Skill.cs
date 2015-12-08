namespace SKP.KRD.Gamification
{
    public abstract class Skill
    {
        public string Name;
        public SkillValue Value;

        public string Nejm
        {
            get
            {
                return Name;
            }
        }

        public SkillValue Valjue
        {
            get { return Value; }
        }

        public virtual void IncreaseValue()
        {
            if ((int) Value < (int) SkillValue.c)
            {
                Value = (SkillValue) ((int) Value + 1);
            }
        }

        public virtual void DecreaseValue()
        {
            if ((int)SkillValue.a < (int)Value)
            {
                Value = (SkillValue)((int)Value - 1);
            }
        }

    }
}