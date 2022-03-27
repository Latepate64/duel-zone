using Common;

namespace Cards.Cards.DM02
{
    class EngineerKipo : Creature
    {
        public EngineerKipo() : base("Engineer Kipo", 2, 2000, Subtype.Xenoparts, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsDestroyedAbility(new OneShotEffects.MutualManaSacrificeEffect(1)));
        }
    }
}
