﻿using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class BlastoExplosiveSoldier : Creature
    {
        public BlastoExplosiveSoldier() : base("Blasto, Explosive Soldier", 3, 2000, Engine.Subtype.Dragonoid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(Engine.Civilization.Darkness, 2000));
        }
    }
}
