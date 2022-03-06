using Cards.CardFilters;
using Cards.OneShotEffects;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class DarkReversal : Spell
    {
        public DarkReversal() : base("Dark Reversal", 2, Civilization.Darkness)
        {
            ShieldTrigger = true;

            // Return a creature from your graveyard to your hand.
            AddAbilities(new SpellAbility(new SalvageEffect(new OwnersGraveyardCardFilter { CardType = CardType.Creature }, 1, 1, true)));
        }
    }
}
