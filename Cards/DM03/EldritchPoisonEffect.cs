using Engine.Abilities;
using Interfaces;

namespace Cards.DM03;

public sealed class EldritchPoisonEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var controller = Controller;
        var creature = controller.ChooseControlledCreatureOptionally(game, ToString(), Civilization.Darkness);
        if (creature != null)
        {
            game.Destroy(Ability, creature);
            controller.ReturnOwnManaCreature(game, Ability);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new EldritchPoisonEffect();
    }

    public override string ToString()
    {
        return "You may destroy one of your darkness creatures. If you do, return a creature from your mana zone to your hand.";
    }
}
