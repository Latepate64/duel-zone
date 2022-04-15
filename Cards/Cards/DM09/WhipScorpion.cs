using Common;

namespace Cards.Cards.DM09
{
    class WhipScorpion : Creature
    {
        public WhipScorpion() : base("Whip Scorpion", 5, 2000, Engine.Subtype.GiantInsect, Civilization.Nature)
        {
            AddShieldTrigger();
            AddPowerAttackerAbility(3000);
        }
    }
}
