using OneShotEffects;
using Interfaces;

namespace Cards.DM03;

public sealed class SnakeAttack : Spell
{
    public SnakeAttack() : base("Snake Attack", 4, Civilization.Darkness)
    {
        AddSpellAbilities(
            new SnakeAttackEffect(),
            new ShieldBurnEffect(
                minimum: 1,
                maximum: 1,
                ownShields: true
        ));
    }
}
