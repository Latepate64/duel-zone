using Interfaces;

namespace OneShotEffects;

public sealed class ClonedBladeEffect : ClonedEffect
{
    public ClonedBladeEffect(string name) : base(name)
    {
    }

    public ClonedBladeEffect(ClonedBladeEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var creatures = Controller.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByPlayer(
            game, GetOpponent(game).Id).Where(x => x.Power <= 3000), 1, GetAmount(game), ToString());
        game.Destroy(Ability, [.. creatures]);
    }

    public override IOneShotEffect Copy()
    {
        return new ClonedBladeEffect(this);
    }

    public override string ToString()
    {
        return $"Choose an opponent's creature in the battle zone that has power 3000 or less. Then, for each {_name} in each graveyard, you may choose another opponent's creature in the battle zone that has power 3000 or less. Destroy all those creatures.";
    }
}
