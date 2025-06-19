using Effects.Continuous;

namespace Cards.Cards.DM03
{
    class WailingShadowBelbetphlo : Engine.Creature
    {
        public WailingShadowBelbetphlo() : base("Wailing Shadow Belbetphlo", 3, 1000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}
