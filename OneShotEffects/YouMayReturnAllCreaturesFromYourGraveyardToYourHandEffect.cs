using Interfaces;

namespace OneShotEffects;

/// <summary>
/// You may return all creatures from your graveyard to your hand.
/// </summary>
public sealed class YouMayReturnAllCreaturesFromYourGraveyardToYourHandEffect
    : OneShotEffect
{
    private readonly ICardFilter filter;

    public YouMayReturnAllCreaturesFromYourGraveyardToYourHandEffect(
        ICardFilter filter)
    {
        this.filter = filter;
    }

    public YouMayReturnAllCreaturesFromYourGraveyardToYourHandEffect(
        YouMayReturnAllCreaturesFromYourGraveyardToYourHandEffect effect) : base(
        effect)
    {
        filter = effect.filter.Copy();
    }

    public override void Apply(IGame game)
    {
        if (Controller.ChooseToTakeAction(ToString()))
        {
            game.Move(Ability, ZoneType.Graveyard, ZoneType.Hand,
                [.. Controller.Graveyard.GetCards(filter)]);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayReturnAllCreaturesFromYourGraveyardToYourHandEffect(
            this);
    }
}
