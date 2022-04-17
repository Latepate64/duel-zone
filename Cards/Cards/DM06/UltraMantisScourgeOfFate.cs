using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class UltraMantisScourgeOfFate : EvolutionCreature
    {
        public UltraMantisScourgeOfFate() : base("Ultra Mantis, Scourge of Fate", 6, 9000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(8000));
            AddDoubleBreakerAbility();
        }
    }
}
