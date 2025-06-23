using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class AquaGrapplerEffect : OneShotEffect
{
    public AquaGrapplerEffect()
    {
    }

    public AquaGrapplerEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var amount = game.BattleZone.GetCreatures(Ability.Controller.Id).Count(
            x => x != Ability.Source && x.Tapped == true);
        Controller.DrawCardsOptionally(game, Ability, amount);
    }

    public override IOneShotEffect Copy()
    {
        return new AquaGrapplerEffect(this);
    }

    public override string ToString()
    {
        return "You may draw a card for each other tapped creature you have in the battle zone.";
    }
}
