using ContinuousEffects;

namespace Cards.DM03
{
    class WailingShadowBelbetphlo : Engine.Creature
    {
        public WailingShadowBelbetphlo() : base("Wailing Shadow Belbetphlo", 3, 1000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}
