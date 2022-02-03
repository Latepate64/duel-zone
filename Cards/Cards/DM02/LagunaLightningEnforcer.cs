using Cards.CardFilters;
using Common;

namespace Cards.Cards.DM02
{
    class LagunaLightningEnforcer : Creature
    {
        public LagunaLightningEnforcer() : base("Laguna, Lightning Enforcer", 5, Common.Civilization.Light, 2500, Common.Subtype.Berserker)
        {
            // Whenever this creature attacks, search your deck. You may take a spell from your deck, show that spell to your opponent, and put it into your hand. Then shuffle your deck.
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.SearchDeckEffect(new OwnersDeckCardFilter { CardType = CardType.Spell }, true)));
        }
    }
}
