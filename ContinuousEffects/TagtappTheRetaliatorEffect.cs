using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class TagtappTheRetaliatorEffect(int power = 1000) : PowerModifyingMultiplierEffect(power)
{
    public override IContinuousEffect Copy()
    {
        return new TagtappTheRetaliatorEffect();
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power for each water card in your opponent's mana zone.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.GetPlayer(game.GetOpponent(Controller.Id)).ManaZone.GetCardCount(Civilization.Water);
    }
}
