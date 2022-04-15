namespace Cards.Cards.DM06
{
    class RumblesaurQ : Creature
    {
        public RumblesaurQ() : base("Rumblesaur Q", 6, 3000, Engine.Subtype.Survivor, Engine.Subtype.RockBeast, Engine.Civilization.Fire)
        {
            AddSurvivorAbility(new ContinuousEffects.ThisCreatureHasSpeedAttackerEffect());
        }
    }
}
