using Cards.ContinuousEffects;
using Effects.Continuous;
using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class Biancus : Engine.Creature
    {
        public Biancus() : base("Biancus", 6, 3000, Engine.Race.SeaHacker, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddAbilities(new TapAbility(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect()));
        }
    }
}
