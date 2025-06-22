using TriggeredAbilities;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM09;

public class FistsOfForeverEffect : OneShotEffect
{
    public FistsOfForeverEffect()
    {
    }

    public FistsOfForeverEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var creature = Controller.ChooseControlledCreature(game, ToString());
        game.AddDelayedTriggeredAbility(new WheneverSomethingHappensThisTurnAbility(
            new FistsOfForeverAbility(creature), Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new FistsOfForeverEffect(this);
    }

    public override string ToString()
    {
        return "Choose one of your creatures in the battle zone. Whenever that creature wins a battle this turn, untap it.";
    }
}
