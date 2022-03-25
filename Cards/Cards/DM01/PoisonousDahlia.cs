using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class PoisonousDahlia : Creature
    {
        public PoisonousDahlia() : base("Poisonous Dahlia", 4, 5000, Common.Subtype.TreeFolk, Common.Civilization.Nature)
        {
            AddAbilities(new ThisCreatureCannotAttackPlayersAbility());
        }
    }
}
