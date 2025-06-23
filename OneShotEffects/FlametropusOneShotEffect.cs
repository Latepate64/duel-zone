using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class FlametropusOneShotEffect : OneShotEffect
{
    public FlametropusOneShotEffect()
    {
    }

    public FlametropusOneShotEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var player = Controller;
        var card = player.ChooseCardOptionally(player.ManaZone.Cards, ToString());
        if (card != null)
        {
            game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, card);
            game.AddContinuousEffects(Ability, new FlametropusContinuousEffect(Ability.Source));                 
        }
    }

    public override IOneShotEffect Copy()
    {
        return new FlametropusOneShotEffect(this);
    }

    public override string ToString()
    {
        return "You may put a card from your mana zone into your graveyard. If you do, this creature gets \"power attacker +3000\" and \"double breaker\" until the end of the turn.";
    }
}
