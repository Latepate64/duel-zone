using Engine;

namespace Cards.ContinuousEffects;

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
        var creature = Source as Creature;
        if (game.CurrentTurn.CurrentPhase is Engine.Steps.AttackPhase phase && phase.AttackingCreature == creature)
        {
            creature.IncreasePower(GetMultiplier(game) * Power);
        }
    }
}
