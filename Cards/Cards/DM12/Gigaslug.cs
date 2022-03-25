using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM12
{
    class Gigaslug : Creature
    {
        public Gigaslug() : base("Gigaslug", 3, 1000, Subtype.Chimera, Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility(), new SlayerAbility(), new ThisCreatureCannotAttackCreaturesAbility(), new CannotAttackPlayersAbility());
        }
    }
}
