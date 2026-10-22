using StaticAbilities;
using ContinuousEffects.CanAttackUntappedCreatures;
using CardFilters;

namespace Cards.DM01
{
    sealed class GatlingSkyterror : Creature
    {
        public GatlingSkyterror() : base("Gatling Skyterror", 7, 7000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect(new CreatureFilter()));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
