using Cards.OneShotEffects;
using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class BurningPower : Spell
    {
        public BurningPower() : base("Burning Power", 1, Common.Civilization.Fire)
        {
            // One of your creatures gets "power attacker +2000" until the end of the turn. (While attacking, a creature that has "power attacker +2000" gets +2000 power.)
            AddSpellAbilities(new GrantAbilityChoiceEffect(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true, new PowerAttackerAbility(2000)));
        }
    }
}
