using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    class PoisonousDahlia : Creature
    {
        public PoisonousDahlia() : base("Poisonous Dahlia", 4, Civilization.Nature, 5000, Subtype.TreeFolk)
        {
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
