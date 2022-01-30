using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    public class AquaSniper : Creature
    {
        public AquaSniper() : base("Aqua Sniper", 8, Civilization.Water, 5000, Subtype.LiquidPeople)
        {
            // When you put this creature into the battle zone, choose up to 2 creatures in the battle zone and return them to their owners' hands.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BounceEffect(0, 2, new CardFilters.BattleZoneChoosableCreatureFilter())));
        }
    }
}
