using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class RoarOfTheEarthEffect : SelfManaRecoveryEffect
{
    public RoarOfTheEarthEffect() : base(1, 1, true) { }

    public RoarOfTheEarthEffect(SelfManaRecoveryEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new RoarOfTheEarthEffect(this);
    }

    public override string ToString()
    {
        return "Return a creature that costs 6 or more from your mana zone to your hand.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.ManaZone.Creatures.Where(x => x.ManaCost >= 6);
    }
}
