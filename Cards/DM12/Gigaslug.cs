using ContinuousEffects;

namespace Cards.DM12
{
    class Gigaslug : Engine.Creature
    {
        public Gigaslug() : base("Gigaslug", 3, 1000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
