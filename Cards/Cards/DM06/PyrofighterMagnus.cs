﻿using Cards.OneShotEffects;

namespace Cards.Cards.DM06
{
    class PyrofighterMagnus : Creature
    {
        public PyrofighterMagnus() : base("Pyrofighter Magnus", 3, 3000, Common.Subtype.Dragonoid, Common.Civilization.Fire)
        {
            AddSpeedAttackerAbility();
            AddAtTheEndOfYourTurnAbility(new ReturnThisCreatureToYourHandEffect());
        }
    }
}
