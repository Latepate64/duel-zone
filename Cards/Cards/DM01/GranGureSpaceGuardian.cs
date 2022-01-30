using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class GranGureSpaceGuardian : Creature
    {
        public GranGureSpaceGuardian() : base("Gran Gure, Space Guardian", 6, Civilization.Light, 9000, Subtype.Guardian)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
