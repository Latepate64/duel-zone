using ContinuousEffects;

namespace Cards.DM04
{
    class PurplePiercer : Engine.Creature
    {
        public PurplePiercer() : base("Purple Piercer", 3, 2000, Interfaces.Race.BrainJacker, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Interfaces.Civilization.Light), new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Interfaces.Civilization.Light));
        }
    }
}
