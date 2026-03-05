using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class BurnwispLizardEffect : ContinuousEffect, ISpeedAttackerEffect
{
    public BurnwispLizardEffect() : base()
    {
    }

    public bool Applies(ICreature creature, IGame game)
    {
        return creature.Owner == Controller && creature.GetAbilities<Abilities.SilentSkillAbility>().Any();
    }

    public override IContinuousEffect Copy()
    {
        return new BurnwispLizardEffect();
    }

    public override string ToString()
    {
        return "Each of your creatures in the battle zone that has \"silent skill\" has \"speed attacker.\"";
    }
}
