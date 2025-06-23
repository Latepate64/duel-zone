using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class LarbaGeerTheImmaculateEffect : TapAreaOfEffect
{
    public LarbaGeerTheImmaculateEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new LarbaGeerTheImmaculateEffect();
    }

    public override string ToString()
    {
        return "Tap all your opponent's creatures in the battle zone that have \"blocker.\"";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.CreaturesThatHaveBlockerOwnedBy(game.GetOpponent(Ability.Controller));
    }
}
