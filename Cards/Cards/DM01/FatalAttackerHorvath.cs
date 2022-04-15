using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM01
{
    class FatalAttackerHorvath : Creature
    {
        public FatalAttackerHorvath() : base("Fatal Attacker Horvath", 3, 2000, Engine.Subtype.Human, Civilization.Fire)
        {
            AddStaticAbilities(new WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect(Engine.Subtype.Armorloid, 2000));
        }
    }
}
