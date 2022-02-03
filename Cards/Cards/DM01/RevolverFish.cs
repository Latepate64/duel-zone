using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class RevolverFish : Creature
    {
        public RevolverFish() : base("Revolver Fish", 4, Common.Civilization.Water, 5000, Common.Subtype.GelFish)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
