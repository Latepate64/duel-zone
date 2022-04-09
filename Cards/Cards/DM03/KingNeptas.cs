﻿using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM03
{
    class KingNeptas : Creature
    {
        public KingNeptas() : base("King Neptas", 6, 5000, Subtype.Leviathan, Civilization.Water)
        {
            AddWheneverThisCreatureAttacksAbility(new KingNeptasEffect());
        }
    }

    class KingNeptasEffect : OneShotEffects.BounceEffect
    {
        public KingNeptasEffect() : base(new CardFilters.BattleZoneChoosableMaxPowerCreatureFilter(2000), 0, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new KingNeptasEffect();
        }

        public override string ToString()
        {
            return "You may choose a creature in the battle zone that has power 2000 or less and return it to its owner's hand.";
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, source.GetOpponent(game).Id).Where(x => x.Power <= 2000);
        }
    }
}
