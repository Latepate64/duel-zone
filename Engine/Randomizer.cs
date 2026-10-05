using System;
using System.Collections.Generic;
using Interfaces;

namespace Engine;

public sealed class Randomizer : IRandomizer
{
    public void Shuffle(List<ICard> cards)
    {
        Random random = new(Guid.NewGuid().GetHashCode());
        var n = cards.Count;
        while (n > 1)
        {
            n--;
            var k = random.Next(n + 1);
            (cards[n], cards[k]) = (cards[k], cards[n]);
        }
    }
}