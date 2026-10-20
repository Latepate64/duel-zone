using StaticAbilities;
using ContinuousEffects;
using ContinuousEffects.PowerModifying;
using CardFilters;

namespace Cards.DM05
{
    sealed class NocturnalGiant : Creature
    {
        public NocturnalGiant() : base("Nocturnal Giant", 7, 7000, Interfaces.Race.Giant, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect(new CreatureFilter()));
            AddStaticAbilities(new PowerAttackerEffect(7000));
            AddAbilities(new TripleBreakerAbility());
        }
    }
}
