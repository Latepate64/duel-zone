namespace Cards.Cards.DM01
{
    class ArtisanPicora : Creature
    {
        public ArtisanPicora() : base("Artisan Picora", 1, 2000, Engine.Subtype.MachineEater, Common.Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.PutCardsFromYourManaZoneIntoYourGraveyard(1));
        }
    }
}
