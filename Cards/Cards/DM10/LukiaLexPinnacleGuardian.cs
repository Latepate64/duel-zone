using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM10
{
    class LukiaLexPinnacleGuardian : Creature
    {
        public LukiaLexPinnacleGuardian() : base("Lukia Lex, Pinnacle Guardian", 3, 2500, Engine.Race.Guardian, Engine.Civilization.Light, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()));
        }
    }
}
