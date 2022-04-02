﻿using Common;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class EarthRipperTalonOfRage : EvolutionCreature
    {
        public EarthRipperTalonOfRage() : base("Earth Ripper, Talon of Rage", 4, 6000, Subtype.BeastFolk, Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new EarthRipperTalonOfRageEffect());
            AddDoubleBreakerAbility();
        }
    }

    class EarthRipperTalonOfRageEffect : OneShotEffects.ManaRecoveryAreaOfEffect
    {
        public EarthRipperTalonOfRageEffect() : base(new CardFilters.OwnersManaZoneTappedCardFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new EarthRipperTalonOfRageEffect();
        }

        public override string ToString()
        {
            return "Return all tapped cards from your mana zone to your hand.";
        }
    }
}