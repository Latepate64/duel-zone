using Common;

namespace Cards.Cards.DM06
{
    class CutthroatSkyterror : Creature
    {
        public CutthroatSkyterror() : base("Cutthroat Skyterror", 3, 5000, Subtype.ArmoredWyvern, Civilization.Fire)
        {
            AddSpeedAttackerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
            AddAtTheEndOfYourTurnAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect());
        }
    }
}
