using Abilities.Static;
using ContinuousEffects;

namespace Cards.Promo
{
    sealed class AmnisHolyElemental : Creature
    {
        public AmnisHolyElemental() : base("Amnis, Holy Elemental", 7, 5000, Interfaces.Race.AngelCommand, Interfaces.Civilization.Light)
        {
            AddAbilities(new CivilizationBlockerAbility(Interfaces.Civilization.Darkness));
            AddStaticAbilities(new NotDestroyedInBattleEffect(Interfaces.Civilization.Darkness));
        }
    }
}
