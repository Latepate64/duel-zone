using ContinuousEffects;

namespace Cards.DM02
{
    sealed class Gigastand : Creature
    {
        public Gigastand() : base("Gigastand", 4, 3000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new GigastandEffect());
        }
    }
}
