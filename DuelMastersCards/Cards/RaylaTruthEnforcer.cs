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
            // When you put this creature into the battle zone, search your deck. You may take a spell from your deck, show that spell to your opponent, and put it into your hand. Then shuffle your deck.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SearchDeckEffect(new CardTypeFilter(CardType.Spell), true)));
        }
    }
}
