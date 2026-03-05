using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class BonePiercer : Creature
{
    public BonePiercer() : base("Bone Piercer", 2, 1000, Race.BrainJacker, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new BonePiercerEffect()));
    }
}
