using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace OneShotEffects;

public sealed class CometMissileEffect : DestroyEffect
{
    public CometMissileEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new CometMissileEffect();
    }

    public override string ToString()
    {
        return "Destroy one of your opponent's creatures that has \"blocker\" and power 6000 or less.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id).Where(
            x => x.IsBlocker && x.Power <= 6000);
    }
}
