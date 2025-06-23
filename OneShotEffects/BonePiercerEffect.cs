using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class BonePiercerEffect : SelfManaRecoveryEffect
{
    public BonePiercerEffect() : base(0, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new BonePiercerEffect();
    }

    public override string ToString()
    {
        return "You may return a creature from your mana zone to your hand.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.ManaZone.Creatures;
    }
}
