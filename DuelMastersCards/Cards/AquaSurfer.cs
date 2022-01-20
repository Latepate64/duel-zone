using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;

namespace DuelMastersCards.Cards
{
    public class AquaSurfer : Creature
    {
        public AquaSurfer() : base("Aqua Surfer", 6, DuelMastersModels.Civilization.Water, 2000, DuelMastersModels.Subtype.LiquidPeople)
        {
            ShieldTrigger = true;
            // You may choose a creature in the battle zone and return it to its owner's hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BounceEffect(1)));
        }
    }
}
