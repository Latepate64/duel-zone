using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;

namespace DuelMastersCards.Cards
{
    public class KingRippedHide : Creature
    {
        public KingRippedHide() : base("King Ripped-Hide", 7, DuelMastersModels.Civilization.Water, 5000, DuelMastersModels.Subtype.Leviathan)
        {
            // When you put this creature into the battle zone, draw up to 2 cards.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ControllerMayDrawCardsEffect(2)));
        }
    }
}
