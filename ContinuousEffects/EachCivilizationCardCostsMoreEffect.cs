using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public class EachCivilizationCardCostsMoreEffect : ContinuousEffect, ICostModifyingEffect, ICivilizationable
{
    private readonly int _increase;

    protected EachCivilizationCardCostsMoreEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
    {
        Civilization = effect.Civilization;
        _increase = effect._increase;
    }

    public EachCivilizationCardCostsMoreEffect(int increase, Civilization civilization) : base()
    {
        Civilization = civilization;
        _increase = increase;
    }

    public Civilization Civilization { get; }

    public override IContinuousEffect Copy()
    {
        return new EachCivilizationCardCostsMoreEffect(this);
    }

    public int GetChange(ICard card, IGame game)
    {
        return card.HasCivilization(Civilization) ? _increase : 0;
    }

    public override string ToString()
    {
        return $"Each {Civilization} creature costs {_increase} more to summon, and each {Civilization} spell costs {_increase} more to cast.";
    }
}
