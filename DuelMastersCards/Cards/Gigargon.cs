using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Gigargon : Creature
    {
        public Gigargon() : base("Gigargon", 8, Civilization.Darkness, 3000, Subtype.Chimera)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ReturnCardsFromGraveyardToHandEffect(2, new CardTypeFilter(CardType.Creature))));
        }
    }
}
