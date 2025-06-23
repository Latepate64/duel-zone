using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace OneShotEffects;

public sealed class BonfireLizardEffect : OneShotEffects.DestroyEffect
{
    public BonfireLizardEffect() : base(0, 2, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new BonfireLizardEffect();
    }

    public override string ToString()
    {
        return "Destroy up to 2 of your opponent's creatures that have \"blocker.\"";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id).Where(
            x => x.IsBlocker);
    }
}
