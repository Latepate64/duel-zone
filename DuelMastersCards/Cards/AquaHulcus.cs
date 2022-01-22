using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class AquaHulcus : Creature
    {
        public AquaHulcus() : base("Aqua Hulcus", 3, Civilization.Water, 2000, Subtype.LiquidPeople)
        {
            // When you put this creature into the battle zone, you may draw a card.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ControllerMayDrawCardsEffect(1)));
        }
    }
}
