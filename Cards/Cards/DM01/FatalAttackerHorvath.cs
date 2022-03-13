using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class FatalAttackerHorvath : Creature
    {
        public FatalAttackerHorvath() : base("Fatal Attacker Horvath", 3, 2000, Common.Subtype.Human, Common.Civilization.Fire)
        {
            // While you have at least 1 Armorloid in the battle zone, this creature gets +2000 power during its attacks.
            AddAbilities(new StaticAbility(new PowerAttackerEffect(2000, new Conditions.HaveAtLeastOneSubtypeCreatureInTheBattleZoneCondition(Common.Subtype.Armorloid))));
        }
    }
}
