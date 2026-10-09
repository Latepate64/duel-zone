using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;
using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class CutthroatSkyterror : Creature
    {
        public CutthroatSkyterror() : base("Cutthroat Skyterror", 3, 5000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddAbilities(new SpeedAttackerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect()));
        }
    }
}
