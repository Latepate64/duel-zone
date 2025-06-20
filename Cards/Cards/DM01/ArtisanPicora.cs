using Abilities.Triggered;

namespace Cards.Cards.DM01
{
    class ArtisanPicora : Engine.Creature
    {
        public ArtisanPicora() : base("Artisan Picora", 1, 2000, Engine.Race.MachineEater, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.PutCardsFromYourManaZoneIntoYourGraveyard(1)));
        }
    }
}
