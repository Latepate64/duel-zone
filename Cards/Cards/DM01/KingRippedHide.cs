using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class KingRippedHide : Creature
    {
        public KingRippedHide() : base("King Ripped-Hide", 7, Common.Civilization.Water, 5000, Common.Subtype.Leviathan)
        {
            // When you put this creature into the battle zone, draw up to 2 cards.
            Abilities.Add(new PutIntoPlayAbility(new ControllerMayDrawCardsEffect(2)));
        }
    }
}
