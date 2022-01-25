using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Zepimeteus : Creature
    {
        public Zepimeteus() : base("Zepimeteus", 1, Civilization.Water, 2000, Subtype.SeaHacker)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
