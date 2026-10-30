using Interfaces;

namespace Models;

public class ChooseCardsEvent(
    int minimum, int maximum, params ICard[] choosableCards) : IChoiceEvent<ICard>
{
    public int Minimum { get; } = minimum;
    public int Maximum { get; } = maximum;
    public ICard[] ChoosableCards { get; } = choosableCards;
    public ICard[] Chosen { get; } = [];

    public IGameEvent Copy()
    {
        return new ChooseCardsEvent(Minimum, Maximum, [.. ChoosableCards.Select(x => x.Copy())]);
    }
}
