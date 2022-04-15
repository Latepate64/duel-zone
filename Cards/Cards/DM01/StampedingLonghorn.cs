using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class StampedingLonghorn : Creature
    {
        public StampedingLonghorn() : base("Stampeding Longhorn", 5, 4000, Engine.Subtype.HornedBeast, Common.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(3000));
        }
    }
}
