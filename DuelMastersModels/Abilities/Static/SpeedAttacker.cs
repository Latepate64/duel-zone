using System;

namespace DuelMastersModels.Abilities.Static
{
    public class SpeedAttacker : StaticAbility
    {
        public SpeedAttacker(Guid creature, Guid controller) : base(creature, controller)
        { }

        protected SpeedAttacker(SpeedAttacker ability) : base(ability) { }

        public override Ability Copy()
        {
            return new SpeedAttacker(this);
        }
    }
}

