using Interfaces;

namespace OneShotEffects;

/// <summary>
/// You may draw a card for each of your other creatures in the battle zone.
/// </summary>
public sealed class YouMayDrawCardForEachOtherCreatureYouControlEffect
    : OneShotEffect
{
    private readonly ICardFilter filter;

    public YouMayDrawCardForEachOtherCreatureYouControlEffect(
        ICardFilter filter)
    {
        this.filter = filter;
    }

    public YouMayDrawCardForEachOtherCreatureYouControlEffect(
        YouMayDrawCardForEachOtherCreatureYouControlEffect effect) : base(
            effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        var count = game.BattleZone.GetNumberOfOtherCreaturesControllerByPlayer(
            (ICreature)Source, filter);
        Controller.DrawCardsOptionally(game, Ability, count);
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayDrawCardForEachOtherCreatureYouControlEffect(this);
    }
}
