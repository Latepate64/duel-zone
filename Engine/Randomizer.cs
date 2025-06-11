using System;

namespace Engine;

public class Randomizer : IRandomizer
{
    public ICard[] Shuffle(ICard[] cards)
    {
        Random random = new(Guid.NewGuid().GetHashCode());
        int n = cards.Length;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            (cards[n], cards[k]) = (cards[k], cards[n]);
        }
        return cards;
    }
}