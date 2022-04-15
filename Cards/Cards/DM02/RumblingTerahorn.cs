﻿namespace Cards.Cards.DM02
{
    class RumblingTerahorn : Creature
    {
        public RumblingTerahorn() : base("Rumbling Terahorn", 5, 3000, Engine.Subtype.HornedBeast, Engine.Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchCreatureEffect());
        }
    }
}
