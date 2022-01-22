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
            // When you put this creature into the battle zone, you may choose a creature in the battle zone and return it to its owner's hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BounceEffect(1)));
        }
    }
}
