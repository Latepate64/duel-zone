using System.Collections.Generic;
using Interfaces;
using Interfaces.ContinuousEffects;
using ContinuousEffects;

namespace Cards.DM09;

public class VreemahFreakyMojoTotemContinuousEffect : GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect
{
    public VreemahFreakyMojoTotemContinuousEffect() : base(2000)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new VreemahFreakyMojoTotemContinuousEffect();
    }

    public override string ToString()
    {
        return "Each Beast Folk in the battle zone gets +2000 power and \"double breaker\" until the end of the turn.";
    }

    protected override List<ICreature> GetAffectedCards(IGame game)
    {
        return [.. game.BattleZone.GetCreatures(Race.BeastFolk)];
    }
}
