using Interfaces;

namespace OneShotEffects;

public sealed class ExtremeCrawlerEffect : BounceAreaOfEffect
{
    public ExtremeCrawlerEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ExtremeCrawlerEffect();
    }

    public override string ToString()
    {
        return "Return all your other creatures from the battle zone to your hand.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetOtherCreatures(Ability.Controller.Id, Ability.Source.Id);
    }
}
