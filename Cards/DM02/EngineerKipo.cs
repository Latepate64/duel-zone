using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class EngineerKipo : Creature
{
    public EngineerKipo() : base("Engineer Kipo", 2, 2000, Race.Xenoparts,
        Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new MutualManaSacrificeEffect(1)));
    }
}