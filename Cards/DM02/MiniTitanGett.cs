using ContinuousEffects;

namespace Cards.DM02
{
    class MiniTitanGett : Engine.Creature
    {
        public MiniTitanGett() : base("Mini Titan Gett", 2, 2000, Interfaces.Race.Human, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureAttacksEachTurnIfAbleEffect());
            AddStaticAbilities(new PowerAttackerEffect(1000));
        }
    }
}
