using ContinuousEffects;

namespace Cards.DM09
{
    class WhipScorpion : Engine.Creature
    {
        public WhipScorpion() : base("Whip Scorpion", 5, 2000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddShieldTrigger();
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
