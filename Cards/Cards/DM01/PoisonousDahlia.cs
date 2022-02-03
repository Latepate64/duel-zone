using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class PoisonousDahlia : Creature
    {
        public PoisonousDahlia() : base("Poisonous Dahlia", 4, Common.Civilization.Nature, 5000, Common.Subtype.TreeFolk)
        {
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
