using Engine;
using Engine.Abilities;
using Interfaces;

namespace TriggeredAbilities;

public class SimianWarriorGrashAbility : DestroyedAbility
{
    public SimianWarriorGrashAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public SimianWarriorGrashAbility(SimianWarriorGrashAbility ability) : base(ability)
    {
    }

    public override IAbility Copy()
    {
        return new SimianWarriorGrashAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever one of your Armorloids is destroyed, {GetEffectText()}";
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return card.Owner == Controller && card.HasRace(Race.Armorloid);
    }
}
