using Cards.StaticAbilities;

namespace Cards.Cards.DM06
{
    class KanesillTheExplorer : Creature
    {
        public KanesillTheExplorer() : base("Kanesill, the Explorer", 3, Common.Civilization.Light, 4000, Common.Subtype.Gladiator)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
