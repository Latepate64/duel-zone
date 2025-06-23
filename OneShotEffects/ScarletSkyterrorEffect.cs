using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class ScarletSkyterrorEffect : DestroyAreaOfEffect
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
