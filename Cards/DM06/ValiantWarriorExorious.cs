using CardFilters;
using ContinuousEffects.CanAttackUntappedCreatures;
using ContinuousEffects.PowerModifying;

namespace Cards.DM06
{
    sealed class ValiantWarriorExorious : Creature
    {
        public ValiantWarriorExorious() : base("Valiant Warrior Exorious", 6, 4000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect(new CreatureFilter()));
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
