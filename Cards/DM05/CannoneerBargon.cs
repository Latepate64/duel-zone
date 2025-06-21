using ContinuousEffects;

namespace Cards.DM05
{
    class CannoneerBargon : Engine.Creature
    {
        public CannoneerBargon() : base("Cannoneer Bargon", 4, 4000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddShieldTrigger();
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
