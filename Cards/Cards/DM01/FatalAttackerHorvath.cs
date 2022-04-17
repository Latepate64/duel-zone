using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class FatalAttackerHorvath : Creature
    {
        public FatalAttackerHorvath() : base("Fatal Attacker Horvath", 3, 2000, Engine.Race.Human, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(Engine.Race.Armorloid, 2000));
        }
    }
}
