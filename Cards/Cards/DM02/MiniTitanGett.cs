using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM02
{
    class MiniTitanGett : Engine.Creature
    {
        public MiniTitanGett() : base("Mini Titan Gett", 2, 2000, Engine.Race.Human, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureAttacksEachTurnIfAbleEffect());
            AddStaticAbilities(new PowerAttackerEffect(1000));
        }
    }
}
