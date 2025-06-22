using TriggeredAbilities;
using OneShotEffects;
using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.Promo;

public sealed class OlgateNightmareSamurai : Creature
{
    public OlgateNightmareSamurai() : base("Olgate, Nightmare Samurai", 7, 6000, Race.DemonCommand, Civilization.Darkness)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddTriggeredAbility(new OlgateAbility(new YouMayUntapThisCreatureEffect()));
    }
}
