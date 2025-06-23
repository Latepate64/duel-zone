using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class SkyswordTheSavageVizierEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        Controller.PutFromTopOfDeckIntoManaZone(game, 1, Ability);
        Controller.PutFromTopOfDeckIntoShieldZone(1, game, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new SkyswordTheSavageVizierEffect();
    }

    public override string ToString()
    {
        return "Put the top card of your deck into your mana zone. Then add the top card of your deck to your shields face down.";
    }
}
