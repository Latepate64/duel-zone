using DuelMastersCards.CardFilters;
using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class ThornyMandra : Creature
    {
        public ThornyMandra() : base("Thorny Mandra", 5, Civilization.Nature, 4000, Subtype.TreeFolk)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ControllerPutsCardsFromGraveyardIntoManaZoneResolvable(new CardTypeFilter(CardType.Creature))));
        }
    }
}
