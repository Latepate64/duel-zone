using DuelMastersCards.CardFilters;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM02
{
    class AmberPiercer : Creature
    {
        public AmberPiercer() : base("Amber Piercer", 4, Civilization.Darkness, 2000, Subtype.BrainJacker)
        {
            // Whenever this creature attacks, you may return a creature from your graveyard to your hand.
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.SalvageEffect(new OwnersGraveyardCardFilter { CardType = CardType.Creature }, 0, 1, true)));
        }
    }
}
