using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class ArtisanPicora : Creature
    {
        public ArtisanPicora() : base("Artisan Picora", 1, 2000, Common.Subtype.MachineEater, Common.Civilization.Fire)
        {
            // When you put this creature into the battle zone, put 1 card from your mana zone into your graveyard.
            Abilities.Add(new PutIntoPlayAbility(new ManaBurnEffect(new OwnersManaZoneCardFilter(), 1, 1, true)));
        }
    }
}
