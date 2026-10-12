using Interfaces;

namespace OneShotEffects;

public sealed class ShieldBurnEffect : CardMovingChoiceEffect<ICard>
{
    private readonly bool ownShields; 

    public ShieldBurnEffect(
        int minimum,
        int maximum,
        bool ownShields) : base(
            minimum,
            maximum,
            controllerChooses: true,
            ZoneType.ShieldZone,
            ZoneType.Graveyard)
    {
        this.ownShields = ownShields;
    }

    private ShieldBurnEffect(ShieldBurnEffect effect) : base(effect)
    {
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
            return Controller.ShieldZone.Cards;
        }
        else
        {
            return Controller.ShieldZone.Cards;
        }
    }
}
