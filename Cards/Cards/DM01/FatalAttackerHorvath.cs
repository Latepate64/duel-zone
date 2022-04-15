using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class FatalAttackerHorvath : Creature
    {
        public FatalAttackerHorvath() : base("Fatal Attacker Horvath", 3, 2000, Engine.Subtype.Human, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect(Engine.Subtype.Armorloid, 2000));
        }
    }
}
