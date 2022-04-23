namespace Cards.Cards.DM10
{
    class HustleBerry : SilentSkillCreature
    {
        public HustleBerry() : base("Hustle Berry", 2, 1000, Engine.Race.WildVeggies, Engine.Civilization.Nature)
        {
            AddSilentSkillAbility(new OneShotEffects.PutTopCardOfDeckIntoManaZoneEffect());
        }
    }
}
