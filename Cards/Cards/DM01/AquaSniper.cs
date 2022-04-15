namespace Cards.Cards.DM01
{
    class AquaSniper : Creature
    {
        public AquaSniper() : base("Aqua Sniper", 8, 5000, Engine.Subtype.LiquidPeople, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect());
        }
    }
}
