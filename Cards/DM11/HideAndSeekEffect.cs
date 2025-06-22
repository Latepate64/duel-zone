using Engine.Abilities;
using Interfaces;

namespace Cards.DM11;

public class HideAndSeekEffect : OneShotEffect
{
    public HideAndSeekEffect()
    {
    }

    public HideAndSeekEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var controller = Controller;
        var creature = controller.ChooseOpponentsNonEvolutionCreature(game, ToString());
        game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, creature);
        game.GetOpponent(controller).DiscardAtRandom(game, 1, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new HideAndSeekEffect(this);
    }

    public override string ToString()
    {
        return "Choose one of your opponent's non-evolution creatures in the battle zone and return it to his hand. Then he discards a card at random from his hand.";
    }
}
