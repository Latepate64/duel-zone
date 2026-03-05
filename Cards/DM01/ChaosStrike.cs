using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class ChaosStrike : Spell
{
    public ChaosStrike() : base("Chaos Strike", 2, Civilization.Fire)
    {
        AddSpellAbilities(new ChaosStrikeOneShotEffect());
    }
}
