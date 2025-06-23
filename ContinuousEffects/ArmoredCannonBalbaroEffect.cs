using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ArmoredCannonBalbaroEffect(int power = 2000) : ContinuousEffects.PowerAttackerMultiplierEffect(power)
{
    public override IContinuousEffect Copy()
    {
        return new ArmoredCannonBalbaroEffect();
    }

    public override string ToString()
    {
        return $"While attacking, this creature gets +{Power} power for each other Human in the battle zone.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.BattleZone.GetOtherCreatureCount(Source.Id, Race.Human);
    }
}
