using Common;

namespace Cards.Cards.DM06
{
    class UltraMantisScourgeOfFate : EvolutionCreature
    {
        public UltraMantisScourgeOfFate() : base("Ultra Mantis, Scourge of Fate", 6, 9000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerAbility(8000), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
