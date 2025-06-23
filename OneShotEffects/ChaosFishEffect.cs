using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class ChaosFishEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var amount = game.BattleZone.GetCreatures(Ability.Controller.Id, Civilization.Water).Count(
            x => x != Ability.Source);
        Controller.DrawCardsOptionally(game, Ability, amount);
    }

    public override IOneShotEffect Copy()
    {
        return new ChaosFishEffect();
    }

    public override string ToString()
    {
        return "You may draw a card for each of your other water creatures in the battle zone.";
    }
}
