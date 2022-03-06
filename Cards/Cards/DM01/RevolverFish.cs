using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class RevolverFish : Creature
    {
        public RevolverFish() : base("Revolver Fish", 4, 5000, Common.Subtype.GelFish, Common.Civilization.Water)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
