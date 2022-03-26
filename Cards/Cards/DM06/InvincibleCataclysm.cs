﻿using Common;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class InvincibleCataclysm : Spell
    {
        public InvincibleCataclysm() : base("Invincible Cataclysm", 13, Civilization.Fire)
        {
            AddSpellAbilities(new InvincibleCataclysmEffect());
        }
    }

    class InvincibleCataclysmEffect : OneShotEffects.ShieldBurnEffect
    {
        public InvincibleCataclysmEffect() : base(new CardFilters.OpponentsShieldZoneCardFilter(), 0, 3, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new InvincibleCataclysmEffect();
        }

        public override string ToString()
        {
            return "Choose up to 3 of your opponent's shields and put them into his graveyard.";
        }
    }
}
