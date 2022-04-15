﻿using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM02
{
    class Corile : Creature
    {
        public Corile() : base("Corile", 5, 2000, Engine.Subtype.CyberLord, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new CorileEffect(1, 1, true));
        }
    }

    class CorileEffect : CardMovingChoiceEffect
    {
        public CorileEffect(CorileEffect effect) : base(effect)
        {
        }

        public CorileEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.Deck)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new CorileEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your opponent's creatures in the battle zone and put it on top of his deck.";
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id);
        }
    }
}
