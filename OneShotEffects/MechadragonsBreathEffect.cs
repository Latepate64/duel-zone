using Interfaces;

namespace OneShotEffects;

public sealed class MechadragonsBreathEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var power = Controller.ChooseNumber(ToString(), 0, 6000);
        game.Destroy(Ability, [.. game.BattleZone.Creatures.Where(x => x.Power == power)]);
    }

    public override IOneShotEffect Copy()
    {
        return new MechadragonsBreathEffect();
    }

    public override string ToString()
    {
        return "Choose a number less than or equal to 6000. Destroy all creatures that have that power.";
    }
}
