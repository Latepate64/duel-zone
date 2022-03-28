using Common;

namespace Cards.Cards.DM07
{
    class ValkrowzerUltraRockBeast : EvolutionCreature
    {
        public ValkrowzerUltraRockBeast() : base("Valkrowzer, Ultra Rock Beast", 6, 9000, Subtype.RockBeast, Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.StealthEffect(Civilization.Water));
            AddDoubleBreakerAbility();
        }
    }
}
