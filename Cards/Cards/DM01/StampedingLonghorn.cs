using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class StampedingLonghorn : Engine.Creature
    {
        public StampedingLonghorn() : base("Stampeding Longhorn", 5, 4000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(3000));
        }
    }
}
