using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class CrystalPaladinEffect : BounceAreaOfEffect
{
    public CrystalPaladinEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new CrystalPaladinEffect();
    }

    public override string ToString()
    {
        return "Return all creatures in the battle zone that have \"blocker\" to their owners' hands.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.CreaturesThatHaveBlocker;
    }
}
