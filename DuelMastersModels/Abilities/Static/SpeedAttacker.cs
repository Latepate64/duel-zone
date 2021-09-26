using System;

namespace DuelMastersModels.Abilities.StaticAbilities
{
    internal class SpeedAttacker : StaticAbility
    {
        internal SpeedAttacker(Guid creature, Guid controller) : base(creature, controller)
        { }

        protected SpeedAttacker(SpeedAttacker ability) : base(ability) { }

        public override StaticAbility Copy()
        {
            return new SpeedAttacker(this);
        }
    }
}

