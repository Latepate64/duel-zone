using Interfaces;

namespace Cards.DM07;

public sealed class CosmicNebula : EvolutionCreature
{
    public CosmicNebula() : base("Cosmic Nebula", 5, 3000, Race.CyberVirus, Civilization.Water)
    {
        AddTriggeredAbility(new CosmicNebulaAbility());
    }
}
