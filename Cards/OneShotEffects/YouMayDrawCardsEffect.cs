using System;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects;

public class YouMayDrawCardsEffect : OneShotEffect
{
    public int Maximum { get; }

    public YouMayDrawCardsEffect(int maximum) : base()
    {
        Maximum = maximum;
    }

    YouMayDrawCardsEffect(YouMayDrawCardsEffect effect)
    {
        Maximum = effect.Maximum;
    }

    public override void Apply(IGame game)
    {
        Controller.DrawCardsOptionally(game, Ability, Maximum);
    }

    public override YouMayDrawCardsEffect Copy()
    {
        return new YouMayDrawCardsEffect(this);
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj)
            && obj is YouMayDrawCardsEffect effect
            && Maximum == effect.Maximum;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Maximum);
    }
}
