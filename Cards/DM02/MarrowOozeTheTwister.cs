using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM02;

public class MarrowOozeTheTwister : Creature
{
    public MarrowOozeTheTwister() : base("Marrow Ooze, the Twister", 1, 1000, Race.LivingDead, Civilization.Darkness)
    {
        AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        AddTriggeredAbility(new WhenThisCreatureAttacksPlayerAbility(new MarrowOozeTheTwisterEffect()));
    }
}
