﻿using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM06
{
    class MigasaAdeptOfChaos : Creature
    {
        public MigasaAdeptOfChaos() : base("Migasa, Adept of Chaos", 3, 2000, Race.Human, Civilization.Fire)
        {
            AddTapAbility(new MigasaAdeptOfChaosEffect());
        }
    }

    class MigasaAdeptOfChaosEffect : OneShotEffects.CardSelectionEffect
    {
        public MigasaAdeptOfChaosEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MigasaAdeptOfChaosEffect();
        }

        public override string ToString()
        {
            return "One of your fire creatures in the battle zone gets \"double breaker\" until the end of the turn.";
        }

        protected override void Apply(IAbility source, params ICard[] cards)
        {
            Game.AddContinuousEffects(Ability, new ContinuousEffects.ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(new StaticAbilities.DoubleBreakerAbility(), cards));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Game.BattleZone.GetCreatures(Applier, Civilization.Fire);
        }
    }
}
