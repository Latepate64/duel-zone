using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM12;

public sealed class ClonedSpikeHornEffect(string name, int power = 3000) : PowerModifyingMultiplierEffect(power)
{
    public override IContinuousEffect Copy()
    {
        return new ClonedSpikeHornEffect(name, Power);
    }

    public override string ToString()
    {
        return $"This creature gets +{Power} power for each {name} in each graveyard.";
    }

    protected override int GetMultiplier(IGame game)
    {
        return game.Players.SelectMany(x => x.Graveyard.Cards).Count(x => x.Name == name);
    }
}
