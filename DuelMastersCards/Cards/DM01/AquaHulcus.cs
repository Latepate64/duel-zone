using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM01
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
