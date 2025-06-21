using ContinuousEffects;
using Engine.Abilities;

namespace Cards.DM07
{
    class Biancus : Engine.Creature
    {
        public Biancus() : base("Biancus", 6, 3000, Interfaces.Race.SeaHacker, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddAbilities(new TapAbility(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect()));
        }
    }
}
