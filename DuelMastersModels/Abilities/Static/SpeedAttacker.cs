using System;

namespace DuelMastersModels.Abilities.Static
{
    public class SpeedAttacker : StaticAbility
    {
        public SpeedAttacker(Guid source) : base(source)
        { }

        protected SpeedAttacker(SpeedAttacker ability) : base(ability) { }

        public override Ability Copy()
        {
            return new SpeedAttacker(this);
        }
    }
}

