namespace Cards.DM08
{
    sealed class IllusionFish : TurboRushCreature
    {
        public IllusionFish() : base("Illusion Fish", 4, 3000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddTurboRushAbility(new ContinuousEffects.ThisCreatureCannotBeBlockedEffect());
        }
    }
}
