using Common;

namespace Cards.Cards.DM10
{
    class LukiaLexPinnacleGuardian : Creature
    {
        public LukiaLexPinnacleGuardian() : base("Lukia Lex, Pinnacle Guardian", 3, 2500, Engine.Subtype.Guardian, Civilization.Light, Civilization.Nature)
        {
            AddPowerAttackerAbility(3000);
            AddAtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect());
        }
    }
}
