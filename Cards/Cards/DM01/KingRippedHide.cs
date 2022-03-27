using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class KingRippedHide : Creature
    {
        public KingRippedHide() : base("King Ripped-Hide", 7, 5000, Common.Subtype.Leviathan, Common.Civilization.Water)
        {
            // When you put this creature into the battle zone, draw up to 2 cards.
            AddAbilities(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDrawCardsEffect(2)));
        }
    }
}
