using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class SashaPowerEffect : ContinuousEffect, IPowerModifyingEffect
{
    public SashaPowerEffect()
    {
    }

    public SashaPowerEffect(SashaPowerEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new SashaPowerEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        throw new System.NotImplementedException();
        // if (game.CurrentTurn.CurrentPhase is AttackPhase a)
        // {
        //     var against = a.GetCreatureBattlingAgainst(Source as ICreature);
        //     if (against != null && against.IsDragon)
        //     {
        //         (Source as ICreature).IncreasePower(6000);
        //     }
        // }
    }

    public override string ToString()
    {
        return "While battling a creature that has Dragon in its race, this creature gets +6000 power.";
    }
}
