using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class EmeraldGrass : Creature
    {
        public EmeraldGrass() : base("Emerald Grass", 2, 3000, Common.Subtype.StarlightTree, Common.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddAbilities(new CannotAttackPlayersAbility());
        }
    }
}
