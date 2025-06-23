using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class BloodwingMantisEffect : SelfManaRecoveryEffect
{
    public BloodwingMantisEffect() : base(2, 2, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new BloodwingMantisEffect();
    }

    public override string ToString()
    {
        return "Return 2 creatures from your mana zone to your hand.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.ManaZone.Creatures;
    }
}
