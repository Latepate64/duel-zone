namespace Models;

public partial class Card
{
    public override bool Equals(object? obj)
    {
        if (obj is not Card card) return false;
        if (!Civilizations.SequenceEqual(card.Civilizations)) return false;
        if (Cost != card.Cost) return false;
        if (Name != card.Name) return false;
        return true;
    }
}
