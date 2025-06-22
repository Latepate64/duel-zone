using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM01;

public class ScarletSkyterrorEffect : DestroyAreaOfEffect
{
    public ScarletSkyterrorEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ScarletSkyterrorEffect();
    }

    public override string ToString()
    {
        return "Destroy all creatures that have \"blocker.\"";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.CreaturesThatHaveBlocker;
    }
}
