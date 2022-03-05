using Common;

namespace Cards.Cards.DM05
{
    class BombatGeneralOfSpeed : Creature
    {
        public BombatGeneralOfSpeed() : base("Bombat, General of Speed", 5, Civilization.Fire, 3000, Subtype.Dragonoid)
        {
            Abilities.Add(new StaticAbilities.SpeedAttackerAbility());
        }
    }
}
