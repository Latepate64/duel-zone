using Interfaces;

namespace OneShotEffects;

public sealed class GhastlyDrainEffect : ChooseAnyNumberOfCardsEffect
{
    public GhastlyDrainEffect() : base()
    {
    }

    public GhastlyDrainEffect(GhastlyDrainEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new GhastlyDrainEffect(this);
    }

    public override string ToString()
    {
        return "Choose any number of your shields and put them into your hand. You can't use the \"shield trigger\" abilities of those shields.";
    }

    protected override void Apply(IGame game, IAbility source, params ICard[] cards)
    {
        game.PutFromShieldZoneToHand(cards, false, Ability);
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.ShieldZone.Cards;
    }
}
