using System;
using System.Collections.Generic;

namespace Common
{
    public interface ICard
    {
        CardType CardType { get; set; }
        List<Civilization> Civilizations { get; set; }
        Guid Id { get; set; }
        List<Guid> KnownTo { get; set; }
        int ManaCost { get; set; }
        string Name { get; set; }
        Guid OnTopOf { get; set; }
        Guid Owner { get; set; }
        int? Power { get; set; }
        string RulesText { get; set; }
        bool ShieldTrigger { get; set; }
        List<Subtype> Subtypes { get; set; }
        bool SummoningSickness { get; set; }
        List<Supertype> Supertypes { get; set; }
        bool Tapped { get; set; }
        Guid Underneath { get; set; }
    }
}