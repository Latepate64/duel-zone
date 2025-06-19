using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class ValiantWarriorExorious : Creature
    {
        public ValiantWarriorExorious() : base("Valiant Warrior Exorious", 6, 4000, Engine.Race.Armorloid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
            AddPowerAttackerAbility(3000);
        }
    }
}
