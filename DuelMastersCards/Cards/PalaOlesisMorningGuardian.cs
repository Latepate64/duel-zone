using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class PalaOlesisMorningGuardian : Creature
    {
        public PalaOlesisMorningGuardian() : base("Pala Olesis, Morning Guardian", 3, Civilization.Light, 2500, Subtype.Guardian)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new PalaOlesisAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
