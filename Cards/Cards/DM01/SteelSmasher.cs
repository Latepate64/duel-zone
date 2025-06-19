using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class SteelSmasher : Engine.Creature
    {
        public SteelSmasher() : base("Steel Smasher", 2, 3000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
