namespace Interfaces;

public interface ICard
{
    int ManaCost { get; }
    string Name { get; }
    IPlayer OwnerV2 { get; set; }
    bool Tapped { get; set; }
    int Timestamp { get; }
    ICard Copy();
    bool HasCivilization(params Civilization[] civilizations);
    void ResetToPrintedValues();
    int PhysicalId { get; }
}
