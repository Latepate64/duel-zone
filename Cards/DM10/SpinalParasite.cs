using Interfaces;
using TriggeredAbilities;

namespace Cards.DM10;

public sealed class SpinalParasite : Creature
{
    public SpinalParasite() : base("Spinal Parasite", 5, 2000, Race.BrainJacker, Civilization.Darkness)
    {
        AddTriggeredAbility(new SpinalParasiteAbility());
    }
}
