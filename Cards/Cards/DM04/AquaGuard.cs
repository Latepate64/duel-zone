using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM04
{
    public class AquaGuard : Creature
    {
        public AquaGuard() : base("Aqua Guard", 1, Civilization.Water, 2000, Subtype.LiquidPeople)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
