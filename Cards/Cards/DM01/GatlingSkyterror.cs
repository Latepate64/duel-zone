using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM01
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
