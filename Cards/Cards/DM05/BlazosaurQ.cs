using Common;

namespace Cards.Cards.DM05
{
    class BlazosaurQ : Creature
    {
        public BlazosaurQ() : base("Blazosaur Q", 2, 1000, Civilization.Fire)
        {
            AddSubtypes(Subtype.Survivor, Subtype.RockBeast);
            AddSurvivorAbility(new ContinuousEffects.PowerAttackerEffect(1000));
        }
    }
}
