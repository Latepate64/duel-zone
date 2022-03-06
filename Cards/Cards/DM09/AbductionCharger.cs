using Cards.OneShotEffects;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM09
{
    class AbductionCharger : Spell
    {
        public AbductionCharger() : base("AbductionCharger", 7, Civilization.Water)
        {
            AddAbilities(new SpellAbility(new BounceEffect(0, 2, new CardFilters.BattleZoneCreatureFilter())));
            AddAbilities(new StaticAbilities.ChargerAbility());
        }
    }
}
