using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class BlackFeatherShadowOfRage : Creature
    {
        public BlackFeatherShadowOfRage() : base("Black Feather, Shadow of Rage", 1, Common.Civilization.Darkness, 3000, Common.Subtype.Ghost)
        {
            // When you put this creature into the battle zone, destroy 1 of your creatures.
            Abilities.Add(new PutIntoPlayAbility(new DestroyEffect(new OwnersBattleZoneCreatureFilter(), 1, 1, true)));
        }
    }
}
