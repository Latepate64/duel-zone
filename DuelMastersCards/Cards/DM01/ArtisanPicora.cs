using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class ArtisanPicora : Creature
    {
        public ArtisanPicora() : base("Artisan Picora", 1, Civilization.Fire, 2000, Subtype.MachineEater)
        {
            // When you put this creature into the battle zone, put 1 card from your mana zone into your graveyard.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ManaBurnEffect(new OwnersManaZoneCardFilter(), 1, 1, true)));
        }
    }
}
