using Cards.CardFilters;
using Common;

namespace Cards.Cards.DM02
{
    class AmberPiercer : Creature
    {
        public AmberPiercer() : base("Amber Piercer", 4, Common.Civilization.Darkness, 2000, Common.Subtype.BrainJacker)
        {
            // Whenever this creature attacks, you may return a creature from your graveyard to your hand.
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.SalvageEffect(new OwnersGraveyardCardFilter { CardType = CardType.Creature }, 0, 1, true)));
        }
    }
}
