using Common;

namespace Cards.Cards.DM09
{
    class WhipScorpion : Creature
    {
        public WhipScorpion() : base("Whip Scorpion", 5, 2000, Subtype.GiantInsect, Civilization.Nature)
        {
            ShieldTrigger = true;
            AddPowerAttackerAbility(3000);
        }
    }
}
