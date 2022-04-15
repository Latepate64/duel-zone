using Common;

namespace Cards.Cards.DM03
{
    class SwordButterfly : Creature
    {
        public SwordButterfly() : base("Sword Butterfly", 3, 2000, Engine.Subtype.GiantInsect, Civilization.Nature)
        {
            AddPowerAttackerAbility(3000);
        }
    }
}
