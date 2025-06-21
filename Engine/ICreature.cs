using System.Collections.Generic;
using Interfaces;

namespace Engine;

public interface ICreature : ICard
{
    int? Power { get; }
    int? PrintedPower { get; }
    IList<Race> Races { get; }
    bool SummoningSickness { get; }
    IList<Supertype> Supertypes { get; }
    bool IsNonEvolutionCreature { get; }
    bool IsEvolutionCreature { get; }
    bool IsDragon { get; }
    bool IsBlocker { get; }

    void AddGrantedRace(Race race);
    ICreature Copy();
    bool Equals(object obj);
    bool HasRace(Race race);
    void IncreasePower(int power);
    void RemoveSummoningSickness();
    void ResetToPrintedValues();
}
