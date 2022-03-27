using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class ArtisanPicora : Creature
    {
        public ArtisanPicora() : base("Artisan Picora", 1, 2000, Common.Subtype.MachineEater, Common.Civilization.Fire)
        {
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new PutCardsFromYourManaZoneIntoYourGraveyard(1)));
        }
    }
}
