using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    class DomeShell : Creature
    {
        public DomeShell() : base("Dome Shell", 4, Civilization.Nature, 3000, Subtype.ColonyBeetle)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}
