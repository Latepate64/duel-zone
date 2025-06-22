using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM02;

public class ArmoredBlasterValdiosEffect : ContinuousEffect, IPowerModifyingEffect
{
    public ArmoredBlasterValdiosEffect() : base() { }

    public override IContinuousEffect Copy()
    {
        return new ArmoredBlasterValdiosEffect();
    }

    public void ModifyPower(IGame game)
    {
        game.BattleZone.GetCreatures(Controller.Id).Where(x => !IsSourceOfAbility(x)
            && x.HasRace(Race.Human)).ToList().ForEach(x => x.IncreasePower(1000));
    }

    public override string ToString()
    {
        return "Each of your other Humans in the battle zone gets +1000 power.";
    }
}
