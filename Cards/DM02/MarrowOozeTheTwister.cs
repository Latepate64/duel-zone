using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

public sealed class MarrowOozeTheTwister : Creature
{
    public MarrowOozeTheTwister() : base("Marrow Ooze, the Twister", 1, 1000, Race.LivingDead, Civilization.Darkness)
    {
        AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        AddTriggeredAbility(new WhenThisCreatureAttacksPlayerAbility(new MarrowOozeTheTwisterEffect()));
    }
}
