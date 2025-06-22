using Engine;
using Interfaces;

namespace Cards.DM01;

public class BurningPower : Spell
{
    public BurningPower() : base("Burning Power", 1, Civilization.Fire)
    {
        AddSpellAbilities(new BurningPowerEffect());
    }
}
