namespace Models;

public partial class Spell
{
    public Spell Copy()
    {
        return new Spell
        {
            Abilities = [.. Abilities.Select(x => x.Copy())],
            Civilizations = [.. Civilizations],
            Cost = Cost,
            Name = Name,
        };
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not Spell spell) return false;
        if (!Abilities.SequenceEqual(spell.Abilities)) return false;
        return true;
    }
}