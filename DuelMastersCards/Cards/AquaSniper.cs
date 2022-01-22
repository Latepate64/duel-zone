using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class AquaSniper : Creature
    {
        public AquaSniper() : base("Aqua Sniper", 8, Civilization.Water, 5000, Subtype.LiquidPeople)
        {
            // When you put this creature into the battle zone, choose up to 2 creatures in the battle zone and return them to their owners' hands.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BounceEffect(2)));
        }
    }
}
