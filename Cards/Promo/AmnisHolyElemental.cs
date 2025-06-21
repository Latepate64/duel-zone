namespace Cards.Promo
{
    class AmnisHolyElemental : Engine.Creature
    {
        public AmnisHolyElemental() : base("Amnis, Holy Elemental", 7, 5000, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ContinuousEffects.CivilizationBlockerEffect(Engine.Civilization.Darkness), new ContinuousEffects.NotDestroyedInBattleEffect(Engine.Civilization.Darkness));
        }
    }
}
