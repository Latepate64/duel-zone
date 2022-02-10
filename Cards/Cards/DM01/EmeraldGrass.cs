using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class EmeraldGrass : Creature
    {
        public EmeraldGrass() : base("Emerald Grass", 2, Common.Civilization.Light, 3000, Common.Subtype.StarlightTree)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
