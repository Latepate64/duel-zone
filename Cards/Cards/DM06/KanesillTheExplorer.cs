using Cards.StaticAbilities;

namespace Cards.Cards.DM06
{
    class KanesillTheExplorer : Creature
    {
        public KanesillTheExplorer() : base("Kanesill, the Explorer", 3, 4000, Common.Subtype.Gladiator, Common.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddAbilities(new CannotAttackPlayersAbility());
        }
    }
}
