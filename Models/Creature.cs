namespace Models;

public partial class Creature
{
    public Creature Copy()
    {
        return new Creature
        {
            Abilities = [.. Abilities.Select(x => x.Copy())],
            Civilizations = [.. Civilizations],
            Cost = Cost,
            Name = Name,
            Power = Power,
            Races = [.. Races],
        };
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not Creature creature) return false;
        if (!Abilities.SequenceEqual(creature.Abilities)) return false;
        if (Power != creature.Power) return false;
        if (!Races.SequenceEqual(creature.Races)) return false;
        return true;
    }
}
