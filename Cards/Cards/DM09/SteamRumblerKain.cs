﻿namespace Cards.Cards.DM09
{
    class SteamRumblerKain : Creature
    {
        public SteamRumblerKain() : base("Steam Rumbler Kain", 4, 5000, Engine.Race.Armorloid, Engine.Civilization.Fire)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
        }
    }
}
