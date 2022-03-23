﻿using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM04
{
    class MongrelMan : Creature
    {
        public MongrelMan() : base("Mongrel Man", 5, 2000, Subtype.Hedrian, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WheneverAnotherCreatureIsDestroyedAbility(new ControllerMayDrawCardsEffect(1)));
        }
    }
}