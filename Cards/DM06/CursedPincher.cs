using ContinuousEffects;

namespace Cards.DM06
{
    class CursedPincher : Engine.Creature
    {
        public CursedPincher() : base("Cursed Pincher", 4, 2000, Interfaces.Race.BrainJacker, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
