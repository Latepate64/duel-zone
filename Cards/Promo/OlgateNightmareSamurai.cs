using TriggeredAbilities;
using OneShotEffects;
using ContinuousEffects;
using Engine;

namespace Cards.Promo;

public class OlgateNightmareSamurai : Creature
{
    public OlgateNightmareSamurai() : base("Olgate, Nightmare Samurai", 7, 6000, Race.DemonCommand, Civilization.Darkness)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddTriggeredAbility(new OlgateAbility(new YouMayUntapThisCreatureEffect()));
    }
}
