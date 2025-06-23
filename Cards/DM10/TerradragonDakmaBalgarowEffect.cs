using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM10;

public sealed class TerradragonDakmaBalgarowEffect(int power = 2000) : PowerModifyingMultiplierEffect(power)
{
    public override IContinuousEffect Copy()
    {
        return new TerradragonDakmaBalgarowEffect();
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power for each shield you and your opponent have.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.Players.SelectMany(x => x.ShieldZone.Cards).Count();
    }
}
