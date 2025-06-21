using System.Collections.Generic;
using Interfaces;

namespace Engine;

public interface ICreature : ICard
{
    int? Power { get; }
    int? PrintedPower { get; }
    List<Race> Races { get; }
    bool SummoningSickness { get; }
    List<Supertype> Supertypes { get; }
    bool IsNonEvolutionCreature { get; }
    bool IsEvolutionCreature { get; }
    bool IsDragon { get; }
    bool IsBlocker { get; }

    void AddGrantedRace(Race race);
    Creature Copy();
    bool Equals(object obj);
    bool HasRace(Race race);
    void IncreasePower(int power);
    void ResetToPrintedValues();
}
