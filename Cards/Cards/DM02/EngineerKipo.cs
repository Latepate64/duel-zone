using Common;

namespace Cards.Cards.DM02
{
    class EngineerKipo : Creature
    {
        public EngineerKipo() : base("Engineer Kipo", 2, 2000, Engine.Subtype.Xenoparts, Civilization.Fire)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.MutualManaSacrificeEffect(1));
        }
    }
}
