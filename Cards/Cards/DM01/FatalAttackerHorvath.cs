using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM01
{
    class FatalAttackerHorvath : Creature
    {
        public FatalAttackerHorvath() : base("Fatal Attacker Horvath", 3, 2000, Subtype.Human, Civilization.Fire)
        {
            AddAbilities(new WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksAbility(Subtype.Armorloid, 2000));
        }
    }
}
