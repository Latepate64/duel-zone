using OneShotEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class ClonedSpiralEffect : ClonedEffect
{
    public ClonedSpiralEffect(string name) : base(name)
    {
    }

    public ClonedSpiralEffect(ClonedSpiralEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var creatures = Controller.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByAnyone(
            game, GetOpponent(game).Id), 1, GetAmount(game), ToString());
        game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new ClonedSpiralEffect(this);
    }

    public override string ToString()
    {
        return $"Choose a creature in battle zone. Then, for each {_name} in each graveyard, you may choose another creature in the battle zone. Return all those creature to their owner's hands.";
    }
}
