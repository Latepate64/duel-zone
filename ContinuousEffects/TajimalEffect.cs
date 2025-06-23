using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class TajimalEffect : ContinuousEffect, IPowerModifyingEffect
{
    public TajimalEffect()
    {
    }

    public TajimalEffect(TajimalEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new TajimalEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        throw new System.NotImplementedException();
        // if (game.CurrentTurn.CurrentPhase is AttackPhase a)
        // {
        //     var against = a.GetCreatureBattlingAgainst(Source as ICreature);
        //     if (against != null && against.HasCivilization(Civilization.Fire))
        //     {
        //         (Source as ICreature).IncreasePower(4000);
        //     }
        // }
    }

    public override string ToString()
    {
        return "While battling a fire creature, this creature gets +4000 power.";
    }
}
