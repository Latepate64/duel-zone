using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

/// <summary>
/// Players can't cast spells other than light spells.
/// </summary>
public sealed class AlcadeiasLordOfSpiritsEffect : ContinuousEffect,
    ICannotUseCardEffect
{
    public AlcadeiasLordOfSpiritsEffect(
        AlcadeiasLordOfSpiritsEffect effect) : base(effect)
    {
    }

    public AlcadeiasLordOfSpiritsEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new AlcadeiasLordOfSpiritsEffect(this);
    }

    public bool Applies(ICard card, IGameState state)
    {
        if (card is not ISpell spell) return false;
        if (spell.HasCivilization(Civilization.Light)) return false;
        return true;
    }
}
