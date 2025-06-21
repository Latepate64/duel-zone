using ContinuousEffects;

namespace Cards.DM01
{
    class DeathligerLionOfChaos : Engine.Creature
    {
        public DeathligerLionOfChaos() : base("Deathliger, Lion of Chaos", 7, 9000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
