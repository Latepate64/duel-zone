using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

public sealed class MetalwingSkyterror : Creature
{
    public MetalwingSkyterror() : base("Metalwing Skyterror", 7, 6000, Race.ArmoredWyvern, Civilization.Fire)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new MetalwingSkyterrorEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
