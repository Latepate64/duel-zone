using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class ArtisanPicora : Creature
    {
        public ArtisanPicora() : base("Artisan Picora", 1, 2000, Engine.Race.MachineEater, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.PutCardsFromYourManaZoneIntoYourGraveyard(1)));
        }
    }
}
