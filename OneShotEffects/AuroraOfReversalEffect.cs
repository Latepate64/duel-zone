using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class AuroraOfReversalEffect : ChooseAnyNumberOfCardsEffect
{
    public AuroraOfReversalEffect() : base()
    {
    }

    public AuroraOfReversalEffect(AuroraOfReversalEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new AuroraOfReversalEffect(this);
    }

    public override string ToString()
    {
        return "Choose any number of your shields and put them into your mana zone.";
    }

    protected override void Apply(IGame game, IAbility source, params ICard[] cards)
    {
        game.Move(Ability, ZoneType.ShieldZone, ZoneType.ManaZone, cards);
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.ShieldZone.Cards;
    }
}
