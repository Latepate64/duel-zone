using System.Collections.Generic;

namespace Engine;

public interface IRandomizer
{
    void Shuffle(List<Card> cards);
}
