using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class CursedPincher : Engine.Creature
    {
        public CursedPincher() : base("Cursed Pincher", 4, 2000, Engine.Race.BrainJacker, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
