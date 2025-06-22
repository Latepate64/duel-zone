using Engine.Abilities;
using Interfaces;

namespace Cards.DM07;

public class MiraclePortalOneShotEffect : OneShotEffect
{
    public MiraclePortalOneShotEffect()
    {
    }

    public MiraclePortalOneShotEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var creature = Controller.ChooseControlledCreature(game, ToString());
        if (creature != null)
        {
            game.AddContinuousEffects(Ability, new MiraclePortalContinuousEffect(creature));
        }
    }

    public override IOneShotEffect Copy()
    {
        return new MiraclePortalOneShotEffect(this);
    }

    public override string ToString()
    {
        return "Choose one of your creatures in the battle zone. This turn, it can't be blocked and you ignore any effects that would prevent that creature from attacking your opponent.";
    }
}
