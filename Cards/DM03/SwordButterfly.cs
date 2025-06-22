using ContinuousEffects;

namespace Cards.DM03
{
    sealed class SwordButterfly : Engine.Creature
    {
        public SwordButterfly() : base("Sword Butterfly", 3, 2000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
        }
    }
}
