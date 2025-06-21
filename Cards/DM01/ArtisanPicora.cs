using TriggeredAbilities;

namespace Cards.DM01
{
    class ArtisanPicora : Engine.Creature
    {
        public ArtisanPicora() : base("Artisan Picora", 1, 2000, Interfaces.Race.MachineEater, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.PutCardsFromYourManaZoneIntoYourGraveyard(1)));
        }
    }
}
