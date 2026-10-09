using Abilities.Static;
using CardFilters;
using ContinuousEffects;
using Interfaces;

namespace Cards.Promo
{
    sealed class AmnisHolyElemental : Creature
    {
        public AmnisHolyElemental() : base("Amnis, Holy Elemental", 7, 5000, Race.AngelCommand, Civilization.Light)
        {
            AddAbilities(new BlockerAbility(new CivilizationCreatureFilter(Civilization.Darkness)));
            AddStaticAbilities(new NotDestroyedInBattleEffect(Civilization.Darkness));
        }
    }
}
