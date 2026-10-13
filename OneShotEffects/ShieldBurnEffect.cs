using Interfaces;

namespace OneShotEffects;

public sealed class ShieldBurnEffect : CardMovingChoiceEffect<ICard>
{
    private readonly ICardFilter filter;
    private readonly bool ownShields; 

    public ShieldBurnEffect(
        int minimum,
        int maximum,
        ICardFilter filter,
        bool ownShields) : base(
            minimum,
            maximum,
            controllerChooses: true,
            ZoneType.ShieldZone,
            ZoneType.Graveyard)
    {
        this.filter = filter;
        this.ownShields = ownShields;
    }

    private ShieldBurnEffect(ShieldBurnEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        ownShields = effect.ownShields;
    }

    public override IOneShotEffect Copy()
    {
        return new ShieldBurnEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        if (ownShields)
        {
            return Applier.ShieldZone.Cards;
        }
        else
        {
            return Applier.Opponent.ShieldZone.Cards;
        }
    }
}
