using Common;

namespace Cards.Cards.Promo
{
    class AmnisHolyElemental : Creature
    {
        public AmnisHolyElemental() : base("Amnis, Holy Elemental", 7, 5000, Engine.Subtype.AngelCommand, Civilization.Light)
        {
            AddStaticAbilities(new ContinuousEffects.CivilizationBlockerEffect(Civilization.Darkness), new ContinuousEffects.NotDestroyedInBattleEffect(Civilization.Darkness));
        }
    }
}
