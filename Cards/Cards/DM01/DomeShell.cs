using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class DomeShell : Creature
    {
        public DomeShell() : base("Dome Shell", 4, 3000, Common.Subtype.ColonyBeetle, Common.Civilization.Nature)
        {
            AddAbilities(new PowerAttackerAbility(2000));
        }
    }
}
