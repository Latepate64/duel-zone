using Engine.Abilities;
using Interfaces;

namespace Cards.DM05;

public sealed class MiracleQuestDrawEffect : OneShotEffect
{
    public MiracleQuestDrawEffect()
    {
    }

    public MiracleQuestDrawEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        // TODO: Should retrieve amount based on the actual attack, now calculates all attacks by attacker (in rare cases could be more than one attack)
        throw new System.NotImplementedException();
        // var amount = game.CurrentTurn.GameEvents.OfType<CreatureBreaksShieldsEvent>().Where(x => x.Attacker == Ability.Source).Sum(x => x.BreakAmount);
        // for (int i = 0; i < amount; ++i)
        // {
        //     if (Controller.ChooseToTakeAction("You may draw 2 cards."))
        //     {
        //         Controller.DrawCards(2, game, Ability);
        //     }
        //     else
        //     {
        //         break;
        //     }
        // }
    }

    public override IOneShotEffect Copy()
    {
        return new MiracleQuestDrawEffect(this);
    }

    public override string ToString()
    {
        return "You may draw 2 cards for each shield it broke.";
    }
}
