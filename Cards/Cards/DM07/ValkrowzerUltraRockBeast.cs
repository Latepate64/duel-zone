namespace Cards.Cards.DM07
{
    class ValkrowzerUltraRockBeast : EvolutionCreature
    {
        public ValkrowzerUltraRockBeast() : base("Valkrowzer, Ultra Rock Beast", 6, 9000, Engine.Race.RockBeast, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.StealthEffect(Engine.Civilization.Water));
            AddDoubleBreakerAbility();
        }
    }
}
