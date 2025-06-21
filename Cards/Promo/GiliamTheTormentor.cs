namespace Cards.Promo
{
    class GiliamTheTormentor : Engine.Creature
    {
        public GiliamTheTormentor() : base("Giliam, the Tormentor", 7, 5000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ContinuousEffects.CivilizationBlockerEffect(Interfaces.Civilization.Light), new ContinuousEffects.NotDestroyedInBattleEffect(Interfaces.Civilization.Light));
        }
    }
}
