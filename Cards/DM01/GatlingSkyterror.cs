using Abilities.Static;
using ContinuousEffects.CanAttackUntappedCreatures;

namespace Cards.DM01
{
    sealed class GatlingSkyterror : Creature
    {
        public GatlingSkyterror() : base("Gatling Skyterror", 7, 7000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
