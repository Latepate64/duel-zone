using Cards.StaticAbilities;

namespace Cards.Cards.DM04
{
    public class SariusVizierOfSuppression : Creature
    {
        public SariusVizierOfSuppression() : base("Sarius, Vizier of Suppression", 2, Common.Civilization.Light, 3000, Common.Subtype.Initiate)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
