using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM02;

public sealed class MarrowOozeTheTwister : Creature
{
    public MarrowOozeTheTwister() : base("Marrow Ooze, the Twister", 1, 1000, Race.LivingDead, Civilization.Darkness)
    {
        AddAbilities(new BlockerAbility());
        AddTriggeredAbility(new WhenThisCreatureAttacksPlayerAbility(new MarrowOozeTheTwisterEffect()));
    }
}
