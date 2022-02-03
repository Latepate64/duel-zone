using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM01
{
    public class AquaHulcus : Creature
    {
        public AquaHulcus() : base("Aqua Hulcus", 3, Common.Civilization.Water, 2000, Common.Subtype.LiquidPeople)
        {
            // When you put this creature into the battle zone, you may draw a card.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ControllerMayDrawCardsEffect(1)));
        }
    }
}
