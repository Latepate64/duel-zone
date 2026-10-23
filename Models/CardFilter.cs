using Interfaces;

namespace Models;

public partial class CardFilter : ICardFilter
{
    public ICardFilter Copy()
    {
        return new CardFilter();
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
}