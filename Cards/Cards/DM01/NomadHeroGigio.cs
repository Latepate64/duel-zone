using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM01
{
    class NomadHeroGigio : Engine.Creature
    {
        public NomadHeroGigio() : base("Nomad Hero Gigio", 5, 3000, Engine.Race.MachineEater, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
        }
    }
}
