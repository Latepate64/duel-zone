using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class SenatineJadeTree : Creature
    {
        public SenatineJadeTree() : base("Senatine Jade Tree", 3, Common.Civilization.Light, 4000, Common.Subtype.StarlightTree)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
