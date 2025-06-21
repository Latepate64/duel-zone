using ContinuousEffects;

namespace Cards.DM01
{
    class GatlingSkyterror : Engine.Creature
    {
        public GatlingSkyterror() : base("Gatling Skyterror", 7, 7000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
