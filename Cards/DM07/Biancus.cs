using ContinuousEffects;
using Abilities;

namespace Cards.DM07
{
    sealed class Biancus : Creature
    {
        public Biancus() : base("Biancus", 6, 3000, Interfaces.Race.SeaHacker, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddAbilities(new TapAbility(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect()));
        }
    }
}
