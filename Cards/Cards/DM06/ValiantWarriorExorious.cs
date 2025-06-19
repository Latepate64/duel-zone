using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class ValiantWarriorExorious : Engine.Creature
    {
        public ValiantWarriorExorious() : base("Valiant Warrior Exorious", 6, 4000, Engine.Race.Armorloid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
