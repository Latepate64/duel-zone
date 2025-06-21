using Interfaces;

namespace ContinuousEffects;

public abstract class PowerAttackerMultiplierEffect : PowerModifyingMultiplierEffect
{
    protected PowerAttackerMultiplierEffect(int power) : base(power)
    {
    }

    protected PowerAttackerMultiplierEffect(PowerAttackerMultiplierEffect effect) : base(effect)
    {
    }

    public override void ModifyPower(IGame game)
    {
        throw new NotImplementedException();
        // var creature = Source as ICreature;
        // if (game.CurrentTurn.CurrentPhase is Engine.Steps.AttackPhase phase && phase.AttackingCreature == creature)
        // {
        //     creature.IncreasePower(GetMultiplier(game) * Power);
        // }
    }
}
