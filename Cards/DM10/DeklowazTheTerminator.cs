using Engine.Abilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class DeklowazTheTerminator : Creature
{
    public DeklowazTheTerminator() : base(
        "Deklowaz, the Terminator", 6, 5000, Race.SpiritQuartz, Civilization.Darkness, Civilization.Fire)
    {
        AddAbilities(new TapAbility(new DeklowazTheTerminatorEffect()));
    }
}
