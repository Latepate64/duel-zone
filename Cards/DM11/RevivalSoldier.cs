using ContinuousEffects.PowerModifying;
using ContinuousEffects.Replacement;

namespace Cards.DM11
{
    sealed class RevivalSoldier : WaveStrikerCreature
    {
        public RevivalSoldier() : base("Revival Soldier", 3, 2000, Interfaces.Race.Merfolk, Interfaces.Civilization.Water)
        {
            AddWaveStrikerAbility(new ThisCreatureGetsPowerEffect(4000), new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
