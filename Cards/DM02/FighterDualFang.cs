using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM02
{
    class FighterDualFang : EvolutionCreature
    {
        public FighterDualFang() : base("Fighter Dual Fang", 6, 8000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.PutTopTwoCardOfDeckIntoManaZoneEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
