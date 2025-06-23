using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace ContinuousEffects;

public sealed class SpinningTerrorTheWretchedEffect(int power = 2000) : PowerModifyingMultiplierEffect(power)
{
    public override IContinuousEffect Copy()
    {
        return new SpinningTerrorTheWretchedEffect();
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power for each tapped creature your opponent has in the battle zone.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.BattleZone.GetTappedCreatures(game.GetOpponent(Controller.Id)).Count();
    }
}
