using ContinuousEffects;

namespace Cards.DM07
{
    class ValkrowzerUltraRockBeast : EvolutionCreature
    {
        public ValkrowzerUltraRockBeast() : base("Valkrowzer, Ultra Rock Beast", 6, 9000, Interfaces.Race.RockBeast, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new StealthEffect(Interfaces.Civilization.Water));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
