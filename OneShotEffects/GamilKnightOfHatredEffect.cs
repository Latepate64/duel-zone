using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class GamilKnightOfHatredEffect : SalvageCivilizationCreatureEffect
{
    public GamilKnightOfHatredEffect() : base(0, 1)
    {
    }

    public GamilKnightOfHatredEffect(GamilKnightOfHatredEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new GamilKnightOfHatredEffect(this);
    }

    public override string ToString()
    {
        return "You may return a darkness creature from your graveyard to your hand.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.Graveyard.GetCreatures(Civilization.Darkness);
    }
}
