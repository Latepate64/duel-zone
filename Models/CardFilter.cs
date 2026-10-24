using Interfaces;

namespace Models;

public partial class CardFilter : ICardFilter
{
    public ICardFilter Copy()
    {
        return new CardFilter
        {
            Type = Type
        };
    }

    public bool Match(ICard card)
    {
        return Type switch
        {
            CardFilterType.Card => true,
            CardFilterType.Spell => card is ISpell,
            CardFilterType.Creature => card is ICreature,
            CardFilterType.Blocker => card is ICreature creature && creature.HasBlocker,
            _ => throw new NotImplementedException()
        };
    }

    public override bool Equals(object? obj)
    {
        if (obj is not CardFilter filter) return false;
        if (Type != filter.Type) return false;
        return true;
    }
}