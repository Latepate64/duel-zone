using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    public class SenatineJadeTree : Creature
    {
        public SenatineJadeTree() : base("Senatine Jade Tree", 3, Civilization.Light, 4000, Subtype.StarlightTree)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
