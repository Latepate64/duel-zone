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
                    new ShieldBurnEffect(
                        minimum: 1,
                        maximum: 1,
                        filter: new AnyCardFilter(),
                        selectionRange: SelectionRange.OwnCreatures
            )));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
