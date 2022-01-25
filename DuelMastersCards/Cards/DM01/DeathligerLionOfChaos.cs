using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    public class DeathligerLionOfChaos : Creature
    {
        public DeathligerLionOfChaos() : base("Deathliger, Lion of Chaos", 7, Civilization.Darkness, 9000, Subtype.DemonCommand)
        {
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
