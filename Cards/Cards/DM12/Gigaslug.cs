using ContinuousEffects;

namespace Cards.Cards.DM12
{
    class Gigaslug : Engine.Creature
    {
        public Gigaslug() : base("Gigaslug", 3, 1000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
