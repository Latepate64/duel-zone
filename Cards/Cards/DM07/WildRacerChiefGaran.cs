namespace Cards.Cards.DM07
{
    class WildRacerChiefGaran : Creature
    {
        public WildRacerChiefGaran() : base("Wild Racer Chief Garan", 3, 2000, Engine.Subtype.Human, Engine.Civilization.Fire)
        {
            AddPowerAttackerAbility(1000);
            AddStaticAbilities(new ContinuousEffects.StealthEffect(Engine.Civilization.Light));
        }
    }
}
