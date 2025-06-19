using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class DeathligerLionOfChaos : Engine.Creature
    {
        public DeathligerLionOfChaos() : base("Deathliger, Lion of Chaos", 7, 9000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
