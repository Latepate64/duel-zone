using Cards.CardFilters;
using Common;

namespace Cards.Cards.DM02
{
    class AmberPiercer : Creature
    {
        public AmberPiercer() : base("Amber Piercer", 4, 2000, Subtype.BrainJacker, Civilization.Darkness)
        {
            // Whenever this creature attacks, you may return a creature from your graveyard to your hand.
            AddAbilities(new TriggeredAbilities.AttackAbility(new OneShotEffects.SalvageEffect(new OwnersGraveyardCardFilter { CardType = CardType.Creature }, 0, 1, true)));
        }
    }
}
