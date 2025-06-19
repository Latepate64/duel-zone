using Effects.Continuous;

namespace Cards.Cards.DM03
{
    class SwordButterfly : Engine.Creature
    {
        public SwordButterfly() : base("Sword Butterfly", 3, 2000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
