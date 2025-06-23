namespace Cards.Promo
{
    sealed class AmnisHolyElemental : Creature
    {
        public AmnisHolyElemental() : base("Amnis, Holy Elemental", 7, 5000, Interfaces.Race.AngelCommand, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ContinuousEffects.CivilizationBlockerEffect(Interfaces.Civilization.Darkness), new ContinuousEffects.NotDestroyedInBattleEffect(Interfaces.Civilization.Darkness));
        }
    }
}
