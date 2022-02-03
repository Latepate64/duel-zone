using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class DomeShell : Creature
    {
        public DomeShell() : base("Dome Shell", 4, Common.Civilization.Nature, 3000, Common.Subtype.ColonyBeetle)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}
