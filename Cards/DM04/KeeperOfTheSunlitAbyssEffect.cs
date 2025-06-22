using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM04;

public class KeeperOfTheSunlitAbyssEffect : ContinuousEffect, IPowerModifyingEffect
{
    public KeeperOfTheSunlitAbyssEffect() : base() { }

    public override IContinuousEffect Copy()
    {
        return new KeeperOfTheSunlitAbyssEffect();
    }

    public void ModifyPower(IGame game)
    {
        game.BattleZone.Creatures.Where(
            x => x.HasCivilization(Civilization.Light) || x.HasCivilization(Civilization.Darkness)).ToList().ForEach(
                x => x.IncreasePower(1000));
    }

    public override string ToString()
    {
        return "Light creatures and darkness creatures in the battle zone each get +1000 power.";
    }
}
