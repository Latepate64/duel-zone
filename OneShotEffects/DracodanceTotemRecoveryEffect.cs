using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

sealed class DracodanceTotemRecoveryEffect : OneShotEffects.ManaRecoveryEffect
{
    public DracodanceTotemRecoveryEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new DracodanceTotemRecoveryEffect();
    }

    public override string ToString()
    {
        return "Return a creature that has Dragon in its race from your mana zone to your hand.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.ManaZone.Creatures.Where(x => x.IsDragon);
    }
}
