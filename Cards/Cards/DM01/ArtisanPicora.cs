﻿namespace Cards.Cards.DM01
{
    class ArtisanPicora : Creature
    {
        public ArtisanPicora() : base("Artisan Picora", 1, 2000, Engine.Subtype.MachineEater, Engine.Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.PutCardsFromYourManaZoneIntoYourGraveyard(1));
        }
    }
}
