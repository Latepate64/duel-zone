using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class UltimateDragonPowerEffect(int power = 5000) : PowerModifyingMultiplierEffect(power)
{
    public override IContinuousEffect Copy()
    {
        return new UltimateDragonPowerEffect();
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power for each of your other creatures in the battle zone that has Dragon in its race.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.BattleZone.GetOtherCreatures(Controller.Id, Source.Id).Count(x => x.IsDragon);
    }
}
