using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM10
{
    public class BalzaSeekerOfHyperpearls : Creature
    {
        public BalzaSeekerOfHyperpearls() : base("Balza, Seeker of Hyperpearls", 8, Common.Civilization.Light, 4000, Common.Subtype.MechaThunder)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
