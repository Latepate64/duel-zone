namespace Interfaces;

public interface ICard
{
    IList<IAbility> AddedAbilities { get; }
    IList<Civilization> Civilizations { get; }
    bool FaceDown { get; }
    Guid Id { get; }
    int ManaCost { get; }
    string Name { get; }
    ICard OnTopOf { get; }
    IPlayer Owner { get; }
    IPlayerV2 OwnerV2 { get; set; }
    int PhysicalCardId { get; }
    IList<IAbility> PrintedAbilities { get; }
    string RulesText { get; }
    bool ShieldTrigger { get; }
    bool Tapped { get; set; }
    int Timestamp { get; }
    ICard Underneath { get; set; }
    bool IsMultiColored { get; }

    void AddGrantedAbility(IAbility ability);
    ICard Copy();
    IList<ICard> Deconstruct(IList<ICard> deconstructred);
    bool Equals(object obj);
    IEnumerable<T> GetAbilities<T>();
    bool HasCivilization(params Civilization[] civilizations);
    void InitializeAbilities();
    void PutOnTopOf(IEnumerable<ICard> baits);
    void ResetToPrintedValues();
    void SeparateTopCard();
    void SetTimestamp(int v);
    string ToString();
    void TurnFaceUp();
}
