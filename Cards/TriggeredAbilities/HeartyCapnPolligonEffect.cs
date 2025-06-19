using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities;

public class HeartyCapnPolligonEffect : OneShotEffect
{
    public HeartyCapnPolligonEffect()
    {
    }

    public HeartyCapnPolligonEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new HeartyCapnPolligonEffect(this);
    }

    public override void Apply(IGame game)
    {
        game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, Ability.Source);
    }

    public override string ToString()
    {
        return "Return it to your hand.";
    }
}
