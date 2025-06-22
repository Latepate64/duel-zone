using ContinuousEffects;

namespace Cards.DM06
{
    sealed class UltraMantisScourgeOfFate : EvolutionCreature
    {
        public UltraMantisScourgeOfFate() : base("Ultra Mantis, Scourge of Fate", 6, 9000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(8000));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
