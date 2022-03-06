using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM09
{
    class AcidRefluxTheFleshboiler : Creature
    {
        public AcidRefluxTheFleshboiler() : base("Acid Reflux, the Fleshboiler", 5, Civilization.Darkness, 3000, Subtype.DevilMask)
        {
            AddAbilities(new BlockerAbility(), new CannotAttackCreaturesAbility(), new CannotAttackPlayersAbility(), new SlayerAbility());
        }
    }
}
