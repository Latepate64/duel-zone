using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class VessTheOracle : Creature
    {
        public VessTheOracle() : base("Vess, the Oracle", 1, Civilization.Light, 2000, Subtype.LightBringer)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
