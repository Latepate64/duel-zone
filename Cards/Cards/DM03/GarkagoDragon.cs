using Cards.StaticAbilities;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class GarkagoDragon : Creature
    {
        public GarkagoDragon() : base("Garkago Dragon", 7, 6000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddAbilities(new DoubleBreakerAbility(), new StaticAbility(new ContinuousEffects.PowerModifyingMultiplierEffect(1000, new CardFilters.OwnersBattleZoneCivilizationCreatureExceptFilter(Civilization.Fire))), new CanAttackUntappedCreaturesAbility());
        }
    }
}
