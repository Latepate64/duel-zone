using ContinuousEffects;

namespace Cards.Cards.DM01
{
    class PoisonousDahlia : Engine.Creature
    {
        public PoisonousDahlia() : base("Poisonous Dahlia", 4, 5000, Engine.Race.TreeFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
