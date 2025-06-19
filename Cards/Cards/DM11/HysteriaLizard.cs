using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM11
{
    class HysteriaLizard : Engine.Creature
    {
        public HysteriaLizard() : base("Hysteria Lizard", 4, 3000, Engine.Race.MeltWarrior, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureAttacksEachTurnIfAbleEffect());
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
