using Interfaces;

namespace OneShotEffects;

public sealed class BondsOfJusticeEffect : TapAreaOfEffect
{
    public BondsOfJusticeEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new BondsOfJusticeEffect();
    }

    public override string ToString()
    {
        return "Tap all creatures in the battle zone that don't have \"blocker.\"";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.CreaturesThatDoNotHaveBlocker;
    }
}
