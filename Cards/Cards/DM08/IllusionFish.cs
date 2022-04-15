namespace Cards.Cards.DM08
{
    class IllusionFish : TurboRushCreature
    {
        public IllusionFish() : base("Illusion Fish", 4, 3000, Engine.Subtype.GelFish, Engine.Civilization.Water)
        {
            AddTurboRushAbility(new ContinuousEffects.ThisCreatureCannotBeBlockedEffect());
        }
    }
}
