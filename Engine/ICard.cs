using Engine.Abilities;
using Engine.ContinuousEffects;
using Interfaces;
using System;
using System.Collections.Generic;

namespace Engine;

public interface ICard
{
    IList<IAbility> AddedAbilities { get; }
    List<Civilization> Civilizations { get; }
    bool FaceDown { get; }
    Guid Id { get; }
    int ManaCost { get; }
    string Name { get; }
    Card OnTopOf { get; }
    Player Owner { get; }
    PlayerV2 OwnerV2 { get; set; }
    int PhysicalCardId { get; }
    IList<IAbility> PrintedAbilities { get; }
    string RulesText { get; }
    bool ShieldTrigger { get; }
    bool Tapped { get; }
    int Timestamp { get; }
    Card Underneath { get; }
    bool IsMultiColored { get; }

    void AddGrantedAbility(IAbility ability);
    Card Copy();
    IList<Card> Deconstruct(IList<Card> deconstructred);
    bool Equals(object obj);
    IEnumerable<T> GetAbilities<T>();
    IEnumerable<IEvolutionEffect> GetEvolutionEffects();
    IEnumerable<SilentSkillAbility> GetSilentSkillAbilities();
    IEnumerable<TapAbility> GetTapAbilities();
    bool HasCivilization(params Civilization[] civilizations);
    void InitializeAbilities();
    void PutOnTopOf(IEnumerable<Card> baits);
    void ResetToPrintedValues();
    void SeparateTopCard();
    string ToString();
    void TurnFaceUp();
}
