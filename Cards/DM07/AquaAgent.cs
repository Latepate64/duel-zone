using ContinuousEffects;
using Interfaces;

namespace Cards.DM07;

public sealed class AquaAgent : Creature
{
    public AquaAgent() : base("Aqua Agent", 6, 2000, Race.LiquidPeople, Civilization.Water)
    {
        AddStaticAbilities(new StealthEffect(Civilization.Water), new AquaAgentEffect());
    }
}
