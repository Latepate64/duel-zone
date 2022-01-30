using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM04
{
    public class SariusVizierOfSuppression : Creature
    {
        public SariusVizierOfSuppression() : base("Sarius, Vizier of Suppression", 2, Civilization.Light, 3000, Subtype.Initiate)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
