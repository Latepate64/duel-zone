using ContinuousEffects;

namespace Cards.DM01
{
    class StampedingLonghorn : Engine.Creature
    {
        public StampedingLonghorn() : base("Stampeding Longhorn", 5, 4000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(3000));
        }
    }
}
