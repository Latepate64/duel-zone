using System;
using System.Collections.Generic;
using Interfaces;

namespace Engine;

public sealed class Randomizer : IRandomizer
{
    public IRandomizer Copy()
    {
        return new Randomizer();
    }

    public void Shuffle(List<ICard> cards)
    {
        Random random = new(Guid.NewGuid().GetHashCode());
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            (cards[n], cards[k]) = (cards[k], cards[n]);
        }
    }
}