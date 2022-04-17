namespace Cards.Cards.DM06
{
    class CutthroatSkyterror : Creature
    {
        public CutthroatSkyterror() : base("Cutthroat Skyterror", 3, 5000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddSpeedAttackerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
            AddAtTheEndOfYourTurnAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect());
        }
    }
}
