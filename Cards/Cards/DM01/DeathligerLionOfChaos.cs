using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class DeathligerLionOfChaos : Creature
    {
        public DeathligerLionOfChaos() : base("Deathliger, Lion of Chaos", 7, 9000, Common.Subtype.DemonCommand, Common.Civilization.Darkness)
        {
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
