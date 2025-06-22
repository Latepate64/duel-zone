using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM03;

public sealed class SiegBaliculaTheIntenseEffect : ContinuousEffect, IBlockerEffect
{
    public SiegBaliculaTheIntenseEffect() : base() { }

    public bool CanBlock(ICreature blocker, ICreature attacker, IGame game)
    {
        var ability = Ability;
        return blocker.Owner == ability.Controller && blocker != ability.Source && blocker.HasCivilization(
            Civilization.Light);
    }

    public override IContinuousEffect Copy()
    {
        return new SiegBaliculaTheIntenseEffect();
    }

    public override string ToString()
    {
        return "Each of your other light creatures in the battle zone has \"blocker.\"";
    }
}
