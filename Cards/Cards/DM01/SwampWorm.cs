using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class SwampWorm : Creature
    {
        public SwampWorm() : base("Swamp Worm", 7, Common.Civilization.Darkness, 2000, Common.Subtype.ParasiteWorm)
        {
            // When you put this creature into the battle zone, your opponent chooses 1 of his creatures and destroys it.
            Abilities.Add(new PutIntoPlayAbility(new DestroyEffect(new OpponentsBattleZoneCreatureFilter(), 1, 1, false)));
        }
    }
}
