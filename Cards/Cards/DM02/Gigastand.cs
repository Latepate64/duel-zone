using ContinuousEffects;

namespace Cards.Cards.DM02
{
    class Gigastand : Engine.Creature
    {
        public Gigastand() : base("Gigastand", 4, 3000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new GigastandEffect());
        }
    }
}
