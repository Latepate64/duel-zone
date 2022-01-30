using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM06
{
    public class KanesillTheExplorer : Creature
    {
        public KanesillTheExplorer() : base("Kanesill, the Explorer", 3, Civilization.Light, 4000, Subtype.Gladiator)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
