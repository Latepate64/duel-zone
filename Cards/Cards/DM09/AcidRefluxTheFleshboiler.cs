using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM09
{
    public class AcidRefluxTheFleshboiler : Creature
    {
        public AcidRefluxTheFleshboiler() : base("Acid Reflux, the Fleshboiler", 5, Civilization.Darkness, 3000, Subtype.DevilMask)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
            Abilities.Add(new SlayerAbility());
        }
    }
}
