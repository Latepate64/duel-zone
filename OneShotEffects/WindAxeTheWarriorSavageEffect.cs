using Interfaces;

namespace OneShotEffects;

public sealed class WindAxeTheWarriorSavageEffect : OneShotEffect
{
    public WindAxeTheWarriorSavageEffect()
    {
    }

    public WindAxeTheWarriorSavageEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new WindAxeTheWarriorSavageEffect(this);
    }

    public override void Apply(IGame game)
    {
        var player = Controller;
        player.DestroyOpponentsBlocker(game, Ability);
        player.PutFromTopOfDeckIntoManaZone(game, 1, Ability);
    }

    public override string ToString()
    {
        return "Destroy one of your opponent's creatures that has \"blocker.\" Then put the top card of your deck into your mana zone.";
    }
}
