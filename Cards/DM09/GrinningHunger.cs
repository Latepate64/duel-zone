using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class GrinningHunger : Spell
{
    public GrinningHunger() : base("Grinning Hunger", 4, Civilization.Darkness)
    {
        AddSpellAbilities(new GrinningHungerEffect());
    }
}
