using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ArmoredGroblavEffect(int power = 1000) : PowerAttackerMultiplierEffect(power)
{
    public override IContinuousEffect Copy()
    {
        return new ArmoredGroblavEffect(Power);
    }

    public override string ToString()
    {
        return $"While attacking, this creature gets +{Power} power for each other fire creature in the battle zone.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.BattleZone.GetOtherCreatures(Source.Id, Civilization.Fire).Count();
    }
}
