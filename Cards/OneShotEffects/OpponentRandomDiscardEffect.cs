﻿using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class OpponentRandomDiscardEffect : OneShotEffect
    {
        public OpponentRandomDiscardEffect()
        {
        }

        public OpponentRandomDiscardEffect(OneShotEffect effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new OpponentRandomDiscardEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            game.GetOpponent(game.GetPlayer(source.Owner)).DiscardAtRandom(game);
        }

        public override string ToString()
        {
            return "Your opponent discards a card at random from his hand.";
        }
    }
}
