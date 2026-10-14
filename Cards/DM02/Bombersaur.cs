using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

public sealed class Bombersaur : Creature
{
    public Bombersaur() : base("Bombersaur", 5, 5000, Race.RockBeast,
        Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new MutualManaSacrificeEffect(2)));
    }
}
