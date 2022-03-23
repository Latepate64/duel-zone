using Common;

namespace Cards.Cards.DM05
{
    class SmashHornQ : Creature
    {
        public SmashHornQ() : base("Smash Horn Q", 3, 2000, Civilization.Nature)
        {
            AddSubtypes(Subtype.Survivor, Subtype.HornedBeast);
            AddAbilities(new StaticAbilities.SurvivorAbility(new StaticAbilities.ThisCreatureGetsPowerAbility(1000)));
        }
    }
}
