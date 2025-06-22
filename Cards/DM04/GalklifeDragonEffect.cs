using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class GalklifeDragonEffect : DestroyAreaOfEffect
{
    public GalklifeDragonEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new GalklifeDragonEffect();
    }

    public override string ToString()
    {
        return "Destroy all light creatures that have power 4000 or less.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Civilization.Light).Where(x => x.Power <= 4000);
    }
}
