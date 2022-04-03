﻿using Cards.OneShotEffects;
using Common;
namespace Cards.Cards.DM08
{
    class ScreamSlicerShadowOfFear : Creature
    {
        public ScreamSlicerShadowOfFear() : base("Scream Slicer, Shadow of Fear", 6, 4000, Subtype.Ghost, Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(new ScreamSlicerShadowOfFearEffect()));
        }
    }
}
