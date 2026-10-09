using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using Abilities.Static;

namespace Cards.Promo;

public sealed class OlgateNightmareSamurai : Creature
{
    public OlgateNightmareSamurai() : base("Olgate, Nightmare Samurai", 7, 6000, Race.DemonCommand, Civilization.Darkness)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddTriggeredAbility(new OlgateAbility(new YouMayUntapThisCreatureEffect()));
    }
}
