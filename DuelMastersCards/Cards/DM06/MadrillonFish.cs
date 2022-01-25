using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM06
{
    public class MadrillonFish : Creature
    {
        public MadrillonFish() : base("Madrillon Fish", 2, Civilization.Water, 3000, Subtype.GelFish)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
