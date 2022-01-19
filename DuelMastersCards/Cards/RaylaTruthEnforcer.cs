using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class RaylaTruthEnforcer : Creature
    {
        public RaylaTruthEnforcer() : base("Rayla, Truth Enforcer", 6, Civilization.Light, 3000, Subtype.Berserker)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SearchDeckEffect(new CardTypeFilter(CardType.Spell), true)));
        }
    }
}
