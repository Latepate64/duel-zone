using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM10
{
    class LukiaLexPinnacleGuardian : Engine.Creature
    {
        public LukiaLexPinnacleGuardian() : base("Lukia Lex, Pinnacle Guardian", 3, 2500, Interfaces.Race.Guardian, Interfaces.Civilization.Light, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()));
        }
    }
}
