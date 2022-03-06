using Cards.StaticAbilities;

namespace Cards.Cards.DM04
{
    class SariusVizierOfSuppression : Creature
    {
        public SariusVizierOfSuppression() : base("Sarius, Vizier of Suppression", 2, 3000, Common.Subtype.Initiate, Common.Civilization.Light)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
