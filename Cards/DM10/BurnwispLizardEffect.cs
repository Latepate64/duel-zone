using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM10;

public sealed class BurnwispLizardEffect : ContinuousEffect, ISpeedAttackerEffect
{
    public BurnwispLizardEffect() : base()
    {
    }

    public bool Applies(ICreature creature, IGame game)
    {
        return creature.Owner == Controller && creature.GetAbilities<Engine.Abilities.SilentSkillAbility>().Any();
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
