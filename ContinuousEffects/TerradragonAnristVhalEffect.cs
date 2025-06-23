using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class TerradragonAnristVhalEffect(int power = 2000) : PowerModifyingMultiplierEffect(power)
{
    public override IContinuousEffect Copy()
    {
        return new TerradragonAnristVhalEffect();
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power for each of your other nature creatures in the battle zone.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.BattleZone.GetOtherCreatureCount(Controller.Id, Source.Id, Civilization.Nature);
    }
}
