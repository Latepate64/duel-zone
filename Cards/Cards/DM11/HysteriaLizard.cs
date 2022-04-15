using Common;

namespace Cards.Cards.DM11
{
    class HysteriaLizard : Creature
    {
        public HysteriaLizard() : base("Hysteria Lizard", 4, 3000, Engine.Subtype.MeltWarrior, Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureAttacksEachTurnIfAbleEffect());
            AddPowerAttackerAbility(3000);
        }
    }
}
