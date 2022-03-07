using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM06
{
    class Gigagriff : Creature
    {
        public Gigagriff() : base("Gigagriff", 6, 4000, Subtype.Chimera, Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility(), new SlayerAbility(), new CannotAttackCreaturesAbility(), new CannotAttackPlayersAbility());
        }
    }
}
