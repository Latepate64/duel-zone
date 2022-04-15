namespace Cards.Cards.Promo
{
    class AmnisHolyElemental : Creature
    {
        public AmnisHolyElemental() : base("Amnis, Holy Elemental", 7, 5000, Engine.Subtype.AngelCommand, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ContinuousEffects.CivilizationBlockerEffect(Engine.Civilization.Darkness), new ContinuousEffects.NotDestroyedInBattleEffect(Engine.Civilization.Darkness));
        }
    }
}
