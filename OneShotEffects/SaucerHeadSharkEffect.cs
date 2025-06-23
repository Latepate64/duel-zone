using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class SaucerHeadSharkEffect : BounceAreaOfEffect
{
    public SaucerHeadSharkEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new SaucerHeadSharkEffect();
    }

    public override string ToString()
    {
        return "Return each creature in the battle zone that has power 2000 or less to its owner's hand.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreaturesWithMaxPower(2000);
    }
}
