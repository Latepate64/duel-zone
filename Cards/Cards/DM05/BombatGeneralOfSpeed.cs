namespace Cards.Cards.DM05
{
    class BombatGeneralOfSpeed : Creature
    {
        public BombatGeneralOfSpeed() : base("Bombat, General of Speed", 5, 3000, Engine.Subtype.Dragonoid, Engine.Civilization.Fire)
        {
            AddSpeedAttackerAbility();
        }
    }
}
