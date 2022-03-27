using Common;

namespace Cards.Cards.DM02
{
    class FighterDualFang : EvolutionCreature
    {
        public FighterDualFang() : base("Fighter Dual Fang", 6, 8000, Subtype.BeastFolk, Civilization.Nature)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.PutTopCardsOfDeckIntoManaZoneEffect(2)), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
