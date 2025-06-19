using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM06
{
    class Gigagriff : Engine.Creature
    {
        public Gigagriff() : base("Gigagriff", 6, 4000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
