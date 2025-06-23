using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class JusticeJammingEffect : OneShotEffect
{
    public JusticeJammingEffect()
    {
    }

    public JusticeJammingEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var civilization = Controller.ChooseCivilization(
            ToString(), Civilization.Light, Civilization.Water, Civilization.Nature);
        Controller.Tap(game, [.. game.BattleZone.GetCreatures(civilization)]);
    }

    public override IOneShotEffect Copy()
    {
        return new JusticeJammingEffect(this);
    }

    public override string ToString()
    {
        return "Tap all darkness creatures in the battle zone, or tap all fire creatures in the battle zone.";
    }
}
