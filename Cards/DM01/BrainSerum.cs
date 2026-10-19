using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class BrainSerum : Spell
{
    public BrainSerum() : base("Brain Serum", 4, Civilization.Water)
    {
        AddShieldTrigger();
        AddSpellAbilities(new YouMayDrawCardsEffect(2));
    }
}