using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08
{
    sealed class NecrodragonGalbazeek : Creature
    {
        public NecrodragonGalbazeek() : base("Necrodragon Galbazeek", 6, 9000,
            Race.ZombieDragon, Civilization.Darkness)
        {
            AddTriggeredAbility(
                new WheneverThisCreatureAttacksAbility(
                    new CardMovingChoiceEffect(
                        minimum: 1,
                        maximum: 1,
                        controllerChooses: true,
                        filter: new AnyCardFilter(),
                        source: ZoneType.ShieldZone,
                        destination: ZoneType.Graveyard,
                        selectionRange: SelectionRange.OwnCards
            )));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
