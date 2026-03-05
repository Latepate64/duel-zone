using ContinuousEffects;

namespace Cards.DM01
{
    sealed class FatalAttackerHorvath : Creature
    {
        public FatalAttackerHorvath() : base("Fatal Attacker Horvath", 3, 2000, Interfaces.Race.Human, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(2000, Interfaces.Race.Armorloid));
        }
    }
}
