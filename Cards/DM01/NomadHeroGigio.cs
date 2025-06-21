using ContinuousEffects;

namespace Cards.DM01
{
    class NomadHeroGigio : Engine.Creature
    {
        public NomadHeroGigio() : base("Nomad Hero Gigio", 5, 3000, Interfaces.Race.MachineEater, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
        }
    }
}
