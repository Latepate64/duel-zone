using Common;

namespace Cards.Cards.DM05
{
    class BlazosaurQ : Creature
    {
        public BlazosaurQ() : base("Blazosaur Q", 2, 1000, Civilization.Fire)
        {
            AddSubtypes(Subtype.Survivor, Subtype.RockBeast);
            AddAbilities(new StaticAbilities.SurvivorAbility(new StaticAbilities.PowerAttackerAbility(1000)));
        }
    }
}
