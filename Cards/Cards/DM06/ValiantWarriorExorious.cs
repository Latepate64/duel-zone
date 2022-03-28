using Common;

namespace Cards.Cards.DM06
{
    class ValiantWarriorExorious : Creature
    {
        public ValiantWarriorExorious() : base("Valiant Warrior Exorious", 6, 4000, Subtype.Armorloid, Civilization.Fire)
        {
            AddThisCreatureCanAttackUntappedCreaturesAbility();
            AddPowerAttackerAbility(3000);
        }
    }
}
