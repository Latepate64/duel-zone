using Cards.OneShotEffects;
using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class Gigaberos : Creature
    {
        public Gigaberos() : base("Gigaberos", 5, 8000, Common.Subtype.Chimera, Common.Civilization.Darkness)
        {
            // When you put this creature into the battle zone, destroy 2 of your other creatures or destroy this creature.
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new GigaberosEffect()), new DoubleBreakerAbility());
        }
    }
}
