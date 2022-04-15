using Common;

namespace Cards.Cards.DM02
{
    class FighterDualFang : EvolutionCreature
    {
        public FighterDualFang() : base("Fighter Dual Fang", 6, 8000, Engine.Subtype.BeastFolk, Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.PutTopCardsOfDeckIntoManaZoneEffect(2));
            AddDoubleBreakerAbility();
        }
    }
}
