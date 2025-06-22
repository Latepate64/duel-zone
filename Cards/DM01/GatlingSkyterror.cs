using ContinuousEffects;

namespace Cards.DM01
{
    sealed class GatlingSkyterror : Engine.Creature
    {
        public GatlingSkyterror() : base("Gatling Skyterror", 7, 7000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
