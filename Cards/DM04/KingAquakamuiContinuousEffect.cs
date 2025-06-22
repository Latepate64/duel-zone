using ContinuousEffects;
using System.Linq;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM04;

public class KingAquakamuiContinuousEffect : ContinuousEffect, IPowerModifyingEffect
{
    public KingAquakamuiContinuousEffect(KingAquakamuiContinuousEffect effect) : base(effect)
    {
    }

    public KingAquakamuiContinuousEffect() : base()
    {
    }

    public override ContinuousEffect Copy()
    {
        return new KingAquakamuiContinuousEffect(this);
    }

    public override string ToString()
    {
        return "Angel Commands and Demon Commands in the battle zone each get +2000 power.";
    }

    public void ModifyPower(IGame game)
    {
        game.BattleZone.GetCreatures(Race.AngelCommand, Race.DemonCommand).ToList().ForEach(
            x => x.IncreasePower(2000));
    }
}
