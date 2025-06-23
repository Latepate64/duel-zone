using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class PalaOlesisMorningGuardianEffect : ContinuousEffect, IPowerModifyingEffect
{
    public PalaOlesisMorningGuardianEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new PalaOlesisMorningGuardianEffect();
    }

    public void ModifyPower(IGame game)
    {
        throw new System.NotImplementedException();
        // if (game.GetOpponent(Controller.Id) == game.CurrentTurn.ActivePlayer.Id)
        // {
        //     game.BattleZone.GetCreatures(Controller.Id).Where(x => !IsSourceOfAbility(x)).ToList().ForEach(x => x.IncreasePower(2000));
        // }
    }

    public override string ToString()
    {
        return "During your opponent's turn, each of your other creatures gets +2000 power.";
    }
}
