using ContinuousEffects;

namespace Cards.DM03
{
    sealed class MiarCometElemental : Creature
    {
        public MiarCometElemental() : base("Miar, Comet Elemental", 8, 11500, Interfaces.Race.AngelCommand, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
