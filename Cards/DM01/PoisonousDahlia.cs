using ContinuousEffects;

namespace Cards.DM01
{
    class PoisonousDahlia : Engine.Creature
    {
        public PoisonousDahlia() : base("Poisonous Dahlia", 4, 5000, Interfaces.Race.TreeFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
