using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class PhantomFish : Creature
    {
        public PhantomFish() : base("Phantom Fish", 3, 4000, Common.Subtype.GelFish, Common.Civilization.Water)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
