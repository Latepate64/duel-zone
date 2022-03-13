using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class ArmoredWalkerUrherion : Creature
    {
        public ArmoredWalkerUrherion() : base("Armored Walker Urherion", 4, 3000, Common.Subtype.Armorloid, Common.Civilization.Fire)
        {
            // While you have at least 1 Human in the battle zone, this creature gets +2000 power during its attacks.
            AddAbilities(new StaticAbility(new PowerAttackerEffect(2000, new Conditions.HaveAtLeastOneSubtypeCreatureInTheBattleZoneCondition(Common.Subtype.Human))));
        }
    }
}
