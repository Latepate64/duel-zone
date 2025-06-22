using ContinuousEffects;
using System.Collections.Generic;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM07;

public class BattleshipMutantContinuousEffect : GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect
{
    public BattleshipMutantContinuousEffect(BattleshipMutantContinuousEffect effect) : base(effect)
    {
    }

    public BattleshipMutantContinuousEffect() : base(4000)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new BattleshipMutantContinuousEffect();
    }

    public override string ToString()
    {
        return "Until the end of the turn, each of your darkness creatures in the battle zone gets +4000 power and \"double breaker.\"";
    }

    protected override List<ICreature> GetAffectedCards(IGame game)
    {
        return [.. game.BattleZone.GetCreatures(Controller.Id, Civilization.Darkness)];
    }
}
