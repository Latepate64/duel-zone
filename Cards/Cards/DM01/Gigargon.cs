using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class Gigargon : Creature
    {
        public Gigargon() : base("Gigargon", 8, 3000, Common.Subtype.Chimera, Common.Civilization.Darkness)
        {
            // When you put this creature into the battle zone, return up to 2 creatures from your graveyard to your hand.
            AddAbilities(new PutIntoPlayAbility(new SelfSalvageCreatureEffect(0, 2)));
        }
    }
}
