using TriggeredAbilities;

namespace Cards.DM02
{
    class EngineerKipo : Engine.Creature
    {
        public EngineerKipo() : base("Engineer Kipo", 2, 2000, Interfaces.Race.Xenoparts, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.MutualSingleManaSacrificeEffect()));
        }
    }
}
