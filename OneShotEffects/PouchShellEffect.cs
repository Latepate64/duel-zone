using Interfaces;

namespace OneShotEffects;

public sealed class PouchShellEffect : CreatureSelectionEffect
{
    public PouchShellEffect() : base(0, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new PouchShellEffect();
    }

    public override string ToString()
    {
        return "You may choose one of your opponent's evolution creatures in the battle zone and put the top card of that creature into your opponent's graveyard.";
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        cards.ToList().ForEach(x => game.MoveTopCard(x, ZoneType.Graveyard, source));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id).Where(
            x => x.IsEvolutionCreature);
    }
}
