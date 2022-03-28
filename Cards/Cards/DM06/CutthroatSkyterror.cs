using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM06
{
    class CutthroatSkyterror : Creature
    {
        public CutthroatSkyterror() : base("Cutthroat Skyterror", 3, 5000, Subtype.ArmoredWyvern, Civilization.Fire)
        {
            AddSpeedAttackerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
            AddTriggeredAbility(new TriggeredAbilities.AtTheEndOfYourTurnAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect()));
        }
    }
}
