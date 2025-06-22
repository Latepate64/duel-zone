using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM06;

public sealed class MigasaAdeptOfChaos : Creature
{
    public MigasaAdeptOfChaos() : base("Migasa, Adept of Chaos", 3, 2000, Race.Human, Civilization.Fire)
    {
        AddAbilities(new TapAbility(new MigasaAdeptOfChaosEffect()));
    }
}
