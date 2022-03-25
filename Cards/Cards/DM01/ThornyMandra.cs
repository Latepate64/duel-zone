using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM01
{
    class ThornyMandra : Creature
    {
        public ThornyMandra() : base("Thorny Mandra", 5, 4000, Subtype.TreeFolk, Civilization.Nature)
        {
            // When you put this creature into the battle zone, you may put 1 creature from your graveyard into your mana zone.
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new FromGraveyardIntoManaZoneEffect(new OwnersGraveyardCreatureFilter(), 0, 1, true)));
        }
    }
}
