using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Salvage is a term for returning a card from your graveyard to your hand.
/// </summary>
public sealed class SalvageEffect : CardMovingChoiceEffect
{
    private readonly bool excludeSource; 

    public SalvageEffect(
        int minimum,
        int maximum,
        ICardFilter filter,
        bool excludeSource) : base(
            minimum,
            maximum,
            controllerChooses: true,
            filter,
            ZoneType.Graveyard,
            ZoneType.Hand)
    {
        this.excludeSource = excludeSource;
    }

    private SalvageEffect(SalvageEffect effect) : base(effect)
    {
        excludeSource = effect.excludeSource;
    }

    public override IOneShotEffect Copy()
    {
        return new SalvageEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        if (excludeSource)
        {
            return Controller.Graveyard.GetOtherCards(Source, filter);
        }
        else
        {
            return Controller.Graveyard.GetCards(filter);
        }
    }
}
