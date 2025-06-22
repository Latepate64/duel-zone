using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM02;

public class MetalwingSkyterror : Creature
{
    public MetalwingSkyterror() : base("Metalwing Skyterror", 7, 6000, Race.ArmoredWyvern, Civilization.Fire)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new MetalwingSkyterrorEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
