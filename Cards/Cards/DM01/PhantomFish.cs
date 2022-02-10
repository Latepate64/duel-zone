using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class PhantomFish : Creature
    {
        public PhantomFish() : base("Phantom Fish", 3, Common.Civilization.Water, 4000, Common.Subtype.GelFish)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
