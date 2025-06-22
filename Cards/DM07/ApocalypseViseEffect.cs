using Engine.Abilities;
using Engine.Choices;
using Interfaces;

namespace Cards.DM07;

public class ApocalypseViseEffect : OneShotEffect
{
    public ApocalypseViseEffect()
    {
    }

    public ApocalypseViseEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.Destroy(
            Ability,
            [.. Controller.ChooseCards(
                new CardChoice<ICreature>(Controller, ToString(), new ApocalypseViseChoiceMode(),
                [.. game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id)])
                )]);
    }

    public override IOneShotEffect Copy()
    {
        return new ApocalypseViseEffect(this);
    }

    public override string ToString()
    {
        return "Destroy any number of your opponent's creatures that have total power 8000 or less.";
    }
}
