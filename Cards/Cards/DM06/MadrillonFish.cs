using Cards.StaticAbilities;

namespace Cards.Cards.DM06
{
    class MadrillonFish : Creature
    {
        public MadrillonFish() : base("Madrillon Fish", 2, 3000, Common.Subtype.GelFish, Common.Civilization.Water)
        {
            AddAbilities(new BlockerAbility(), new CannotAttackCreaturesAbility(), new CannotAttackPlayersAbility());
        }
    }
}
