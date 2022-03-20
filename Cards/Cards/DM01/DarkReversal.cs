using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM01
{
    class DarkReversal : Spell
    {
        public DarkReversal() : base("Dark Reversal", 2, Civilization.Darkness)
        {
            ShieldTrigger = true;

            // Return a creature from your graveyard to your hand.
            AddSpellAbilities(new SalvageCreatureEffect(1, 1));
        }
    }
}
