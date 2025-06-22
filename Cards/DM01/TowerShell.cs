using ContinuousEffects;

namespace Cards.DM01
{
    sealed class TowerShell : Engine.Creature
    {
        public TowerShell() : base("Tower Shell", 6, 5000, Interfaces.Race.ColonyBeetle, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(4000));
        }
    }
}
