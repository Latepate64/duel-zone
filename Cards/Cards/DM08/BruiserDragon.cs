﻿using Common;

namespace Cards.Cards.DM08
{
    class BruiserDragon : Creature
    {
        public BruiserDragon() : base("Bruiser Dragon", 5, 5000, Engine.Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
        }
    }
}
