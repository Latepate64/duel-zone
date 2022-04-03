﻿using Cards.CardFilters;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM11
{
    class MiraculousSnare : Spell
    {
        public MiraculousSnare() : base("Miraculous Snare", 3, Civilization.Light, Civilization.Water)
        {
            AddSpellAbilities(new MiraculousSnareEffect());
        }
    }

    class MiraculousSnareEffect : OneShotEffects.CardMovingChoiceEffect
    {
        public MiraculousSnareEffect() : base(new BattleZoneChoosableNonEvolutionCreatureFilter(), 1, 1, true, ZoneType.BattleZone, ZoneType.ShieldZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousSnareEffect();
        }

        public override string ToString()
        {
            return "Choose a non-evolution creature in the battle zone and add it to its owner's shields face down.";
        }
    }

    class BattleZoneChoosableNonEvolutionCreatureFilter : BattleZoneChoosableCreatureFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && !card.Supertypes.Contains(Supertype.Evolution);
        }

        public override CardFilter Copy()
        {
            return new BattleZoneChoosableNonEvolutionCreatureFilter();
        }
    }
}