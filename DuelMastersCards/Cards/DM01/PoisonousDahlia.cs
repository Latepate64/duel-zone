using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    class PoisonousDahlia : Creature
    {
        public PoisonousDahlia() : base("Poisonous Dahlia", 4, Civilization.Nature, 5000, Subtype.TreeFolk)
        {
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
