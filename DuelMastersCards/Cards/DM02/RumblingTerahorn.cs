using DuelMastersModels;

namespace DuelMastersCards.Cards.DM02
{
    class RumblingTerahorn : Creature
    {
        public RumblingTerahorn() : base("Rumbling Terahorn", 5, Civilization.Nature, 3000, Subtype.HornedBeast)
        {
            // When you put this creature into the battle zone, search your deck. You may take a creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.
            Abilities.Add(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchDeckEffect(new CardFilters.OwnersDeckCreatureFilter(), true)));
        }
    }
}
