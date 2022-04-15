using Common;

namespace Cards.Cards.DM05
{
    class BlazosaurQ : Creature
    {
        public BlazosaurQ() : base("Blazosaur Q", 2, 1000, Engine.Subtype.Survivor, Engine.Subtype.RockBeast, Civilization.Fire)
        {
            AddSurvivorAbility(new ContinuousEffects.PowerAttackerEffect(1000));
        }
    }
}
