using Cards.StaticAbilities;

namespace Cards.Cards.DM06
{
    class MadrillonFish : Creature
    {
        public MadrillonFish() : base("Madrillon Fish", 2, 3000, Common.Subtype.GelFish, Common.Civilization.Water)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
