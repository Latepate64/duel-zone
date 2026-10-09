using Abilities.Static;
using CardFilters;
using ContinuousEffects;
using Interfaces;

namespace Cards.Promo
{
    sealed class GiliamTheTormentor : Creature
    {
        public GiliamTheTormentor() : base("Giliam, the Tormentor", 7, 5000, Race.DemonCommand, Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility(new CivilizationCreatureFilter(Civilization.Light)));
            AddStaticAbilities(new NotDestroyedInBattleEffect(Civilization.Light));
        }
    }
}
