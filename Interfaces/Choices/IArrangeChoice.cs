namespace Interfaces.Choices;

public interface IArrangeChoice
{
    IEnumerable<ICard> Cards { get; }
    ICard[] Rearranged { get; }
}
