using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class RelentlessBlitzEffect : OneShotEffect
{
    public RelentlessBlitzEffect()
    {
    }

    public RelentlessBlitzEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        game.AddContinuousEffects(Ability, new RelentlessBlitzContinuousEffect(race));
    }

    public override IOneShotEffect Copy()
    {
        return new RelentlessBlitzEffect(this);
    }

    public override string ToString()
    {
        return "Choose a race. This turn, each creature of that race can attack untapped creatures and can't be blocked while attacking a creature.";
    }
}
