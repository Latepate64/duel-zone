using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    public class ArtisanPicora : Creature
    {
        public ArtisanPicora() : base("Artisan Picora", 1, Civilization.Fire, 2000, Subtype.MachineEater)
        {
            // When you put this creature into the battle zone, put 1 card from your mana zone into your graveyard.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingChoiceEffect(new OwnersManaZoneCardFilter(), 1, 1, true, ZoneType.ManaZone, ZoneType.Graveyard)));
        }
    }
}
