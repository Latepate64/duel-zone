using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    public class KingRippedHide : Creature
    {
        public KingRippedHide() : base("King Ripped-Hide", 7, Engine.Civilization.Water, 5000, Engine.Subtype.Leviathan)
        {
            // When you put this creature into the battle zone, draw up to 2 cards.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ControllerMayDrawCardsEffect(2)));
        }
    }
}
