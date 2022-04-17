using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class PurplePiercer : Creature
    {
        public PurplePiercer() : base("Purple Piercer", 3, 2000, Engine.Race.BrainJacker, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Engine.Civilization.Light), new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Engine.Civilization.Light));
        }
    }
}
