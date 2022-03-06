using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class DeathligerLionOfChaos : Creature
    {
        public DeathligerLionOfChaos() : base("Deathliger, Lion of Chaos", 7, Common.Civilization.Darkness, 9000, Common.Subtype.DemonCommand)
        {
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
