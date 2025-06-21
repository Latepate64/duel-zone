using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM02
{
    class FighterDualFang : EvolutionCreature
    {
        public FighterDualFang() : base("Fighter Dual Fang", 6, 8000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.PutTopTwoCardOfDeckIntoManaZoneEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
