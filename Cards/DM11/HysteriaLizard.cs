using ContinuousEffects;

namespace Cards.DM11
{
    sealed class HysteriaLizard : Engine.Creature
    {
        public HysteriaLizard() : base("Hysteria Lizard", 4, 3000, Interfaces.Race.MeltWarrior, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureAttacksEachTurnIfAbleEffect());
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
