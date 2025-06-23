using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM11;

public sealed class MerleeTheOracleEffect : ContinuousEffect, IPowerModifyingEffect
{
    public MerleeTheOracleEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new MerleeTheOracleEffect();
    }

    public void ModifyPower(IGame game)
    {
        game.BattleZone.GetCreatures(Controller.Id).ToList().ForEach(x => x.IncreasePower(1000));
    }

    public override string ToString()
    {
        return "Each of your creatures in the battle zone gets +1000 power.";
    }
}
