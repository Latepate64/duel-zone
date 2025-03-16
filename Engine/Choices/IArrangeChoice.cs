using System.Collections.Generic;

namespace Engine.Choices;

public interface IArrangeChoice
{
    IEnumerable<ICard> Cards { get; }
    ICard[] Rearranged { get; }
}