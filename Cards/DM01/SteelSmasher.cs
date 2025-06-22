using ContinuousEffects;

namespace Cards.DM01
{
    sealed class SteelSmasher : Engine.Creature
    {
        public SteelSmasher() : base("Steel Smasher", 2, 3000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
