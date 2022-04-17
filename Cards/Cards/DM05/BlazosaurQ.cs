namespace Cards.Cards.DM05
{
    class BlazosaurQ : Creature
    {
        public BlazosaurQ() : base("Blazosaur Q", 2, 1000, Engine.Race.Survivor, Engine.Race.RockBeast, Engine.Civilization.Fire)
        {
            AddSurvivorAbility(new ContinuousEffects.PowerAttackerEffect(1000));
        }
    }
}
