﻿using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class BurningPower : Spell
    {
        public BurningPower() : base("Burning Power", 1, Common.Civilization.Fire)
        {
            AddSpellAbilities(new BurningPowerEffect());
        }
    }

    class BurningPowerEffect : GrantChoiceEffect
    {
        public BurningPowerEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BurningPowerEffect();
        }

        public override string ToString()
        {
            return "One of your creatures gets \"power attacker +2000\" until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(2000, cards));
        }
    }
}
