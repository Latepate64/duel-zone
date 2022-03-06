using Common;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class AuroraOfReversal : Spell
    {
        public AuroraOfReversal() : base("Aurora of Reversal", 5, Civilization.Nature)
        {
            // Choose any number of your shields and put them into your mana zone.
            Abilities.Add(new SpellAbility(new OneShotEffects.AuroraOfReversalEffect()));
        }
    }
}
