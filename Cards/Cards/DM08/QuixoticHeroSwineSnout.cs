﻿using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.Cards.DM08
{
    class QuixoticHeroSwineSnout : Creature
    {
        public QuixoticHeroSwineSnout() : base("Quixotic Hero Swine Snout", 2, 1000, Common.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            // Whenever another creature is put into the battle zone, this creature gets +3000 power until the end of the turn.
            AddAbilities(new PutIntoPlayAbility(new QuixoticHeroSwineSnoutEffect(), new CardFilters.AnotherBattleZoneCreatureFilter()));
        }
    }

    class QuixoticHeroSwineSnoutEffect : OneShotEffect
    {
        public override OneShotEffect Copy()
        {
            return new QuixoticHeroSwineSnoutEffect();
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new PowerModifyingEffect(3000, new TargetFilter { Target = source.Source }, new UntilTheEndOfTheTurn()));
            return null;
        }

        public override string ToString()
        {
            return $"This creature gets +3000 power until the end of the turn.";
        }
    }
}
