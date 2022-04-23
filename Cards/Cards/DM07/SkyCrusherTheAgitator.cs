namespace Cards.Cards.DM07
{
    class SkyCrusherTheAgitator : Creature
    {
        public SkyCrusherTheAgitator() : base("Sky Crusher, the Agitator", 7, 4000, Engine.Race.Dragonoid, Engine.Civilization.Fire)
        {
            AddTapAbility(new OneShotEffects.MutualSingleManaSacrificeEffect());
        }
    }
}
