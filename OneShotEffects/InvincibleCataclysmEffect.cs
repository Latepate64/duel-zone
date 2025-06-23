using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class InvincibleCataclysmEffect : ShieldBurnEffect
{
    public InvincibleCataclysmEffect() : base(0, 3, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new InvincibleCataclysmEffect();
    }

    public override string ToString()
    {
        return "Choose up to 3 of your opponent's shields and put them into his graveyard.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return GetOpponent(game).ShieldZone.Cards;
    }
}
