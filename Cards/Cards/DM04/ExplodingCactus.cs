﻿using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class ExplodingCactus : Creature
    {
        public ExplodingCactus() : base("Exploding Cactus", 3, 2000, Engine.Race.TreeFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(Engine.Civilization.Light, 2000));
        }
    }
}
