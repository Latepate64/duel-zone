using Interfaces;

namespace OneShotEffects;

public sealed class VacuumGelEffect : DestroyEffect
{
    public VacuumGelEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new VacuumGelEffect();
    }

    public override string ToString()
    {
        return "Destroy one of your opponent's untapped light or untapped nature creatures.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableUntappedCreaturesControlledByPlayer(game, GetOpponent(game).Id).Where(
            x => x.HasCivilization(Civilization.Light, Civilization.Nature));
    }
}
