using Interfaces;

namespace OneShotEffects;

public sealed class RondobilTheExplorerEffect : CardMovingChoiceEffect<ICreature>
{
    public RondobilTheExplorerEffect() : base(1, 1, true, ZoneType.BattleZone, ZoneType.ShieldZone)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new RondobilTheExplorerEffect();
    }

    public override string ToString()
    {
        return "Add one of your creatures from the battle zone to your shields face down.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id);
    }
}
