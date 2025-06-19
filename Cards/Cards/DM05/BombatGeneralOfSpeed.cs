using Effects.Continuous;

namespace Cards.Cards.DM05
{
    class BombatGeneralOfSpeed : Engine.Creature
    {
        public BombatGeneralOfSpeed() : base("Bombat, General of Speed", 5, 3000, Engine.Race.Dragonoid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
        }
    }
}
