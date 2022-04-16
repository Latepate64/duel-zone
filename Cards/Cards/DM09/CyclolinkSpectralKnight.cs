namespace Cards.Cards.DM09
{
    class CyclolinkSpectralKnight : Creature
    {
        public CyclolinkSpectralKnight() : base("Cyclolink, Spectral Knight", 4, 3000, Engine.Race.RainbowPhantom, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.SearchSpellEffect()));
        }
    }
}
