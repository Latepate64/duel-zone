namespace DuelMastersModels.Abilities.Static
{
    public class SpeedAttacker : StaticAbility
    {
        public SpeedAttacker() : base()
        { }

        protected SpeedAttacker(SpeedAttacker ability) : base(ability) { }

        public override Ability Copy()
        {
            return new SpeedAttacker(this);
        }
    }
}

