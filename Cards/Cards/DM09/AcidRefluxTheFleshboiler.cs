using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM09
{
    class AcidRefluxTheFleshboiler : Creature
    {
        public AcidRefluxTheFleshboiler() : base("Acid Reflux, the Fleshboiler", 5, 3000, Subtype.DevilMask, Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility(), new ThisCreatureCannotAttackCreaturesAbility(), new ThisCreatureCannotAttackPlayersAbility(), new SlayerAbility());
        }
    }
}
