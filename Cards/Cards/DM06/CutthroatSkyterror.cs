using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class CutthroatSkyterror : Creature
    {
        public CutthroatSkyterror() : base("Cutthroat Skyterror", 3, 5000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddAtTheEndOfYourTurnAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect());
        }
    }
}
