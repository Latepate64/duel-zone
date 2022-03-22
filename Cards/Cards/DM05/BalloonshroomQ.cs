using Common;

namespace Cards.Cards.DM05
{
    class BalloonshroomQ : Creature
    {
        public BalloonshroomQ() : base("Balloonshroom Q", 4, 2000, Civilization.Nature)
        {
            AddSubtypes(Subtype.Survivor, Subtype.BalloonMushroom);
            AddAbilities(new StaticAbilities.SurvivorAbility(new StaticAbilities.WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility()));
        }
    }
}
