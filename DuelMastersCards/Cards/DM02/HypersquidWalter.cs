using DuelMastersModels;

namespace DuelMastersCards.Cards.DM02
{
    class HypersquidWalter : Creature
    {
        public HypersquidWalter() : base("Hypersquid Walter", 3, Civilization.Water, 1000, Subtype.CyberLord)
        {
            // Whenever this creature attacks, you may draw a card.
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.ControllerMayDrawCardsEffect(1)));
        }
    }
}
