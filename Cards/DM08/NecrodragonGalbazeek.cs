using Abilities.Static;
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
                        ownShields: true
            )));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
