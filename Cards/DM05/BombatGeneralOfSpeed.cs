using ContinuousEffects;

namespace Cards.DM05
{
    sealed class BombatGeneralOfSpeed : Engine.Creature
    {
        public BombatGeneralOfSpeed() : base("Bombat, General of Speed", 5, 3000, Interfaces.Race.Dragonoid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
        }
    }
}
