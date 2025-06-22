using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM05;

public sealed class BloodwingMantis : Creature
{
    public BloodwingMantis() : base("Bloodwing Mantis", 5, 6000, Race.GiantInsect, Civilization.Nature)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new BloodwingMantisEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
