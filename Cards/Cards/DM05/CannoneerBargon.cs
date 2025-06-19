using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class CannoneerBargon : Engine.Creature
    {
        public CannoneerBargon() : base("Cannoneer Bargon", 4, 4000, Engine.Race.Armorloid, Engine.Civilization.Fire)
        {
            AddShieldTrigger();
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
