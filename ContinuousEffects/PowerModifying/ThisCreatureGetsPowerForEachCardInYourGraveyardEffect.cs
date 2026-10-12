using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.PowerModifying;

/// <summary>
/// This creature gets +x power for each card in your graveyard.
/// </summary>
public sealed class ThisCreatureGetsPowerForEachCardInYourGraveyardEffect
    : PowerModifyingMultiplierEffect
{
    private readonly ICardFilter filter;

    public ThisCreatureGetsPowerForEachCardInYourGraveyardEffect(
        int power, ICardFilter filter) : base(power)
    {
        this.filter = filter;
    }

    public ThisCreatureGetsPowerForEachCardInYourGraveyardEffect(
        ThisCreatureGetsPowerForEachCardInYourGraveyardEffect effect) : base(
            effect)
    {
        filter = effect.filter.Copy();
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsPowerForEachCardInYourGraveyardEffect(this);
    }

    protected override int GetMultiplier(IGame game)
    {
        return Controller.Graveyard.GetNumberOfCards(filter);
    }
}
