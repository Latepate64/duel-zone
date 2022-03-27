using Common;

namespace Cards.Cards.DM06
{
    class ValiantWarriorExorious : Creature
    {
        public ValiantWarriorExorious() : base("Valiant Warrior Exorious", 6, 4000, Subtype.Armorloid, Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.ThisCreatureCanAttackUntappedCreaturesAbility(), new StaticAbilities.PowerAttackerAbility(3000));
        }
    }
}
