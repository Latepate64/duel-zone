namespace Cards.DM10
{
    sealed class HustleBerry : SilentSkillCreature
    {
        public HustleBerry() : base("Hustle Berry", 2, 1000, Interfaces.Race.WildVeggies, Interfaces.Civilization.Nature)
        {
            AddSilentSkillAbility(new OneShotEffects.PutTopCardOfDeckIntoManaZoneEffect());
        }
    }
}
