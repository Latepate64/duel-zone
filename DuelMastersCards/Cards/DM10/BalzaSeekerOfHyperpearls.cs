using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM10
{
    public class BalzaSeekerOfHyperpearls : Creature
    {
        public BalzaSeekerOfHyperpearls() : base("Balza, Seeker of Hyperpearls", 8, Civilization.Light, 4000, Subtype.MechaThunder)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
