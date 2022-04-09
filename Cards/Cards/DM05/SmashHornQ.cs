using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class SmashHornQ : Creature
    {
        public SmashHornQ() : base("Smash Horn Q", 3, 2000, Subtype.Survivor, Subtype.HornedBeast, Civilization.Nature)
        {
            AddSurvivorAbility(new ThisCreatureGetsPowerEffect(1000));
        }
    }
}
