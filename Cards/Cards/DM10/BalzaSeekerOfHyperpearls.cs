using Cards.StaticAbilities;

namespace Cards.Cards.DM10
{
    class BalzaSeekerOfHyperpearls : Creature
    {
        public BalzaSeekerOfHyperpearls() : base("Balza, Seeker of Hyperpearls", 8, 4000, Common.Subtype.MechaThunder, Common.Civilization.Light)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
