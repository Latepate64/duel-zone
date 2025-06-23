using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM07;

public sealed class Cratersaur : Creature
{
    public Cratersaur() : base("Cratersaur", 3, 2000, Race.RockBeast, Civilization.Fire)
    {
        AddStaticAbilities(new CratersaurEffect());
    }
}
