using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class SnakeAttack : Spell
    {
        public SnakeAttack() : base("Snake Attack", 4, Civilization.Darkness)
        {
            // Each of your creatures in the battle zone gets "double breaker" until the end of the turn.
            AddAbilities(new SpellAbility(new GrantAbilityAreaOfEffect(new DoubleBreakerAbility())));

            // Choose one of your shields and put it into your graveyard.
            AddAbilities(new SpellAbility(new SelfShieldBurnEffect()));
        }
    }
}
