using Engine.Abilities;
using Interfaces;
using OneShotEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.DM03;

public sealed class SearingWaveEffect : DestroyAreaOfEffect
{
    public SearingWaveEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new SearingWaveEffect();
    }

    public override string ToString()
    {
        return "Destroy all your opponent's creatures that have power 3000 or less.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(GetOpponent(game).Id).Where(x => x.Power <= 3000);
    }
}
