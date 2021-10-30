using DuelMastersCards.CardFilters;
using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Gigargon : Creature
    {
        public Gigargon() : base("Gigargon", 8, Civilization.Darkness, 3000, Subtype.Chimera)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ReturnCardsFromGraveyardToHandResolvable(2, new CardTypeFilter(CardType.Creature))));
        }
    }
}
