using Interfaces;

namespace OneShotEffects;

/// <summary>
/// You may untap any number of your creatures in the battle zone.
/// </summary>
public sealed class YouMayUntapAnyNumberOfYourCreaturesInTheBattleZoneEffect
    : OneShotEffect
{
    private readonly ICardFilter filter;

    public YouMayUntapAnyNumberOfYourCreaturesInTheBattleZoneEffect(
        ICardFilter filter)
    {
        this.filter = filter;
    }

    public YouMayUntapAnyNumberOfYourCreaturesInTheBattleZoneEffect(
        YouMayUntapAnyNumberOfYourCreaturesInTheBattleZoneEffect effect) : base(
            effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        var creatures = Controller.ChooseAnyNumberOfCards(
            game.BattleZone.GetCreaturesControllerByPlayer(Applier),
            ToString());
        Controller.Untap(game, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayUntapAnyNumberOfYourCreaturesInTheBattleZoneEffect(
            this);
    }
}
