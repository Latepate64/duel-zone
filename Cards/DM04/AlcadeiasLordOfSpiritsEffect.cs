using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM04;

public sealed class AlcadeiasLordOfSpiritsEffect : ContinuousEffect, ICannotUseCardEffect
{
    public AlcadeiasLordOfSpiritsEffect(AlcadeiasLordOfSpiritsEffect effect) : base(effect)
    {
    }

    public AlcadeiasLordOfSpiritsEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new AlcadeiasLordOfSpiritsEffect(this);
    }

    public override string ToString()
    {
        return "Players can't cast spells other than light spells.";
    }

    public bool Applies(ICard card, IGame game)
    {
        return card is Spell && !card.HasCivilization(Civilization.Light);
    }
}
