using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class MiarCometElemental : Creature
    {
        public MiarCometElemental() : base("Miar, Comet Elemental", 8, 11500, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
