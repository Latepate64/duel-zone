using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class SmashHornQ : Creature
    {
        public SmashHornQ() : base("Smash Horn Q", 3, 2000, Civilization.Nature)
        {
            AddSubtypes(Subtype.Survivor, Subtype.HornedBeast);
            AddSurvivorAbility(new ThisCreatureGetsPowerEffect(1000));
        }
    }
}
