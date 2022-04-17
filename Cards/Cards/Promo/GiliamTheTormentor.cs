namespace Cards.Cards.Promo
{
    class GiliamTheTormentor : Creature
    {
        public GiliamTheTormentor() : base("Giliam, the Tormentor", 7, 5000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ContinuousEffects.CivilizationBlockerEffect(Engine.Civilization.Light), new ContinuousEffects.NotDestroyedInBattleEffect(Engine.Civilization.Light));
        }
    }
}
