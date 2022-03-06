using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class AquaHulcus : Creature
    {
        public AquaHulcus() : base("Aqua Hulcus", 3, 2000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            // When you put this creature into the battle zone, you may draw a card.
            Abilities.Add(new PutIntoPlayAbility(new ControllerMayDrawCardsEffect(1)));
        }
    }
}
