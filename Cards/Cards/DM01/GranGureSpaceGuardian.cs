using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class GranGureSpaceGuardian : Engine.Creature
    {
        public GranGureSpaceGuardian() : base("Gran Gure, Space Guardian", 6, 9000, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
