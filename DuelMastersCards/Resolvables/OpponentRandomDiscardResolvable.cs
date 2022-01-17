﻿using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.Resolvables
{
    public class OpponentRandomDiscardResolvable : Resolvable
    {
        public OpponentRandomDiscardResolvable()
        {
        }

        public OpponentRandomDiscardResolvable(Resolvable resolvable) : base(resolvable)
        {
        }

        public override Resolvable Copy()
        {
            return new OpponentRandomDiscardResolvable(this);
        }

        public override void Resolve(Duel duel)
        {
            duel.GetOpponent(duel.GetPlayer(Controller)).DiscardAtRandom(duel);
        }
    }
}
