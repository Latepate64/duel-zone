﻿using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM03
{
    class ChaosFish : Creature
    {
        public ChaosFish() : base("Chaos Fish", 7, 1000, Race.GelFish, Civilization.Water)
        {
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Civilization.Water));
            AddWheneverThisCreatureAttacksAbility(new ChaosFishEffect());
        }
    }

    class ChaosFishEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var amount = game.BattleZone.GetCreatures(source.Controller, Civilization.Water).Count(x => x.Id != source.Source);
            source.GetController(game).DrawCardsOptionally(game, source, amount);
        }

        public override IOneShotEffect Copy()
        {
            return new ChaosFishEffect();
        }

        public override string ToString()
        {
            return "You may draw a card for each of your other water creatures in the battle zone.";
        }
    }
}
