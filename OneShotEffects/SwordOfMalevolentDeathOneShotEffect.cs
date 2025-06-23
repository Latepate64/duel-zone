using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class SwordOfMalevolentDeathOneShotEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreatures(Ability.Controller.Id);
        var power = creatures.Count(x => x.HasCivilization(Civilization.Darkness)) * 1000;
        game.AddContinuousEffects(Ability, new SwordOfMalevolentDeathContinuousEffect(power, [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new SwordOfMalevolentDeathOneShotEffect();
    }

    public override string ToString()
    {
        return "Until the end of the turn, each of your creatures in the battle zone gets \"While attacking, this creature gets +1000 power for each darkness card in your mana zone.\"";
    }
}
