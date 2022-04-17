namespace Cards.Cards.DM02
{
    class FighterDualFang : EvolutionCreature
    {
        public FighterDualFang() : base("Fighter Dual Fang", 6, 8000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.PutTopCardsOfDeckIntoManaZoneEffect(2));
            AddDoubleBreakerAbility();
        }
    }
}
