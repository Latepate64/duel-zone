using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM04;

public class PippieKuppieEffect : ContinuousEffect, IPowerModifyingEffect
{
    public PippieKuppieEffect(PippieKuppieEffect effect) : base(effect)
    {
    }

    public PippieKuppieEffect() : base()
    {
    }

    public override ContinuousEffect Copy()
    {
        return new PippieKuppieEffect(this);
    }

    public override string ToString()
    {
        return "Each Armored Dragon in the battle zone gets +1000 power.";
    }

    public void ModifyPower(IGame game)
    {
        game.BattleZone.GetCreatures(Race.ArmoredDragon).ToList().ForEach(x => x.IncreasePower(1000));
    }
}
