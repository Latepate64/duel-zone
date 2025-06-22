using Engine;
using Interfaces;

namespace Cards.DM01;

public class ChaosStrike : Spell
{
    public ChaosStrike() : base("Chaos Strike", 2, Civilization.Fire)
    {
        AddSpellAbilities(new ChaosStrikeOneShotEffect());
    }
}
