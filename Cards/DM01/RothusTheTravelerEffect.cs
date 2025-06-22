using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM01;

public class RothusTheTravelerEffect : OneShotEffect
{
    public RothusTheTravelerEffect()
    {
    }

    public RothusTheTravelerEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        new List<IPlayer> { Controller, GetOpponent(game) }.ForEach(x => x.Sacrifice(game, Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new RothusTheTravelerEffect(this);
    }

    public override string ToString()
    {
        return "Destroy one of your creatures. Then your opponent chooses one of his creatures and destroys it.";
    }
}
