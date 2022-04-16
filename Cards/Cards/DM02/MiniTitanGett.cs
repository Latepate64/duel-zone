using Cards.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class MiniTitanGett : Creature
    {
        public MiniTitanGett() : base("Mini Titan Gett", 2, 2000, Engine.Race.Human, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureAttacksEachTurnIfAbleEffect());
            AddPowerAttackerAbility(1000);
        }
    }
}
