﻿using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect : ManaFeedEffect
    {
        public PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect();
        }

        public override string ToString()
        {
            return "Put one of your creatures from the battle zone into your mana zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller);
        }
    }
}
