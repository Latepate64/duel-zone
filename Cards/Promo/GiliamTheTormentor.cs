using Abilities.Static;
using ContinuousEffects;

namespace Cards.Promo
{
    sealed class GiliamTheTormentor : Creature
    {
        public GiliamTheTormentor() : base("Giliam, the Tormentor", 7, 5000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new CivilizationBlockerAbility(Interfaces.Civilization.Light));
            AddStaticAbilities(new NotDestroyedInBattleEffect(Interfaces.Civilization.Light));
        }
    }
}
