using Cards.ContinuousEffects;
using Abilities.Triggered;
using Effects.Continuous;

namespace Cards.Cards.DM06
{
    class CutthroatSkyterror : Engine.Creature
    {
        public CutthroatSkyterror() : base("Cutthroat Skyterror", 3, 5000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect()));
        }
    }
}
