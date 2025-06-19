using System.Collections.Generic;
using System.Linq;

namespace Engine;

public class Creature(
    bool tapped,
    List<Civilization> civilizations,
    int manaCost,
    bool summoningSickness,
    int? power,
    string name,
    List<Race> races)
    : Card(
        tapped,
        civilizations,
        manaCost,
        name)
{
    readonly IList<Race> addedRaces = [];
    public int? Power { get; private set; } = power;
    public int? PrintedPower { get; } = power;
    readonly IList<Race> printedRaces = [.. races];
    public List<Race> Races { get; private set; } = [.. races];
    public bool SummoningSickness { get; private set; } = summoningSickness;
    public List<Supertype> Supertypes { get; } = [];

    protected Creature(Creature creature) : this(creature.Tapped, creature.Civilizations, creature.ManaCost,
        creature.SummoningSickness, creature.Power, creature.Name, creature.Races)
    {
        addedRaces = [.. creature.addedRaces];
        printedRaces = [.. creature.printedRaces];
        Races = [.. creature.Races];
        Supertypes = [.. creature.Supertypes];
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is Creature c
            && c.addedRaces.SequenceEqual(addedRaces)
            && c.Power == Power
            && c.PrintedPower == PrintedPower
            && c.printedRaces.SequenceEqual(printedRaces)
            && c.Races.SequenceEqual(Races)
            && c.SummoningSickness == SummoningSickness
            && c.Supertypes.SequenceEqual(Supertypes);
    }

    public bool IsNonEvolutionCreature => !Supertypes.Contains(Supertype.Evolution);
    public bool IsEvolutionCreature => Supertypes.Contains(Supertype.Evolution);

    public bool IsDragon => Races.Intersect([Race.EarthDragon, Race.ZombieDragon, Race.ArmoredDragon,
        Race.VolcanoDragon]).Any();

    public void AddGrantedRace(Race race)
    {
        addedRaces.Add(race);
        if (!Races.Contains(race))
        {
            Races.Add(race);
        }
    }

    public bool HasRace(Race race)
    {
        return Races.Contains(race);
    }

    public override void ResetToPrintedValues()
    {
        base.ResetToPrintedValues();
        Power = PrintedPower;
        Races = [.. printedRaces];
        addedRaces.Clear();
    }

    internal void RemoveSummoningSickness()
    {
        SummoningSickness = false;
    }

    public void IncreasePower(int power)
    {
        Power += power;
    }
    
    public override Creature Copy()
    {
        return new Creature(this);
    }
}