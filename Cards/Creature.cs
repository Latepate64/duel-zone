using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards;

public class Creature : Card, ICreature
{
    readonly IList<Race> addedRaces = [];
    public int Power { get; private set; }
    public int PrintedPower { get; }
    readonly IList<Race> printedRaces = [];
    public IList<Race> Races { get; private set; } = [];
    public bool SummoningSickness { get; private set; }
    public IList<Supertype> Supertypes { get; } = [];

    public Creature(
        bool tapped,
        IList<Civilization> civilizations,
        int manaCost,
        bool summoningSickness,
        int power,
        string name,
        IList<Race> races) : base(
            tapped,
            civilizations,
            manaCost,
            name)
    {
        Power = power;
        PrintedPower = power;
        printedRaces = [.. races];
        Races = [.. races];
        SummoningSickness = summoningSickness;
    }

    protected Creature(string name, int manaCost, int power, Race race, params Civilization[] civilizations) : this(
        tapped: false, [.. civilizations], manaCost, summoningSickness: true, power, name, [race])
    {
    }

    protected Creature(string name, int manaCost, int power, IList<Race> races, params Civilization[] civilizations)
        : this(tapped: false, [.. civilizations], manaCost, summoningSickness: true, power, name, races)
    {
    }

    protected Creature(Creature creature) : base(creature)
    {
        addedRaces = [.. creature.addedRaces];
        Power = creature.Power;
        PrintedPower = creature.PrintedPower;
        printedRaces = [.. creature.printedRaces];
        Races = [.. creature.Races];
        SummoningSickness = creature.SummoningSickness;
        Supertypes = [.. creature.Supertypes];
        
    }

    public override bool Equals(object obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not Creature c) return false;
        if (!c.addedRaces.SequenceEqual(addedRaces)) return false;
        if (!c.Power.Equals(Power)) return false;
        if (!c.PrintedPower.Equals(PrintedPower)) return false;
        if (!c.printedRaces.SequenceEqual(printedRaces)) return false;
        if (!c.Races.SequenceEqual(Races)) return false;
        if (!c.SummoningSickness.Equals(SummoningSickness)) return false;
        if (!c.Supertypes.SequenceEqual(Supertypes)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var x in addedRaces)
        {
            hash.Add(x);
        }
        hash.Add(Power);
        hash.Add(PrintedPower);
        foreach (var x in printedRaces)
        {
            hash.Add(x);
        }
        foreach (var x in Races)
        {
            hash.Add(x);
        }
        hash.Add(SummoningSickness);
        foreach (var x in Supertypes)
        {
            hash.Add(x);
        }
        return hash.ToHashCode();
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

    public bool HasRace(params Race[] races)
    {
        return Races.Intersect(races).Any();
    }

    public override void ResetToPrintedValues()
    {
        base.ResetToPrintedValues();
        Power = PrintedPower;
        Races = [.. printedRaces];
        addedRaces.Clear();
    }

    public void RemoveSummoningSickness()
    {
        SummoningSickness = false;
    }

    public void IncreasePower(int power)
    {
        Power += power;
    }

    protected void AddTriggeredAbility(ITriggeredAbility ability)
    {
        AddAbilities(ability);
    }

    public bool HasBlocker => GetAbilities<IBlockerAbility>().Any();

    public bool HasSilentSkill => GetAbilities<ISilentSkillAbility>().Any();

    public IEnumerable<ITapAbility> GetTapAbilities()
    {
        return GetAbilities<ITapAbility>();
    }

    public IEnumerable<ISilentSkillAbility> GetSilentSkillAbilities()
    {
        return GetAbilities<ISilentSkillAbility>();
    }

    public IEnumerable<IEvolutionEffect> GetEvolutionEffects()
    {
        return GetAbilities<IStaticAbility>().Select(x => x.ContinuousEffects).OfType<IEvolutionEffect>();
    }

    public override ICreature Copy()
    {
        return new Creature(this);
    }

    public bool HasAbility<T>() where T : IAbility
    {
        throw new NotImplementedException();
    }
}