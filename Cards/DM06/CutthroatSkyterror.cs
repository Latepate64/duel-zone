using ContinuousEffects;
using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class CutthroatSkyterror : Engine.Creature
    {
        public CutthroatSkyterror() : base("Cutthroat Skyterror", 3, 5000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect()));
        }
    }
}
