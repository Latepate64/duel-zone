using Interfaces;

namespace OneShotEffects;

public sealed class MiraculousSnareEffect : CardMovingChoiceEffect<ICreature>
{
    public MiraculousSnareEffect() : base(1, 1, true, ZoneType.BattleZone, ZoneType.ShieldZone)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new MiraculousSnareEffect();
    }

    public override string ToString()
    {
        return "Choose a non-evolution creature in the battle zone and add it to its owner's shields face down.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, GetOpponent(game).Id).Where(
            x => !x.IsEvolutionCreature);
    }
}
