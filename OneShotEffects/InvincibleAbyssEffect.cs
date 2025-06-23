using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class InvincibleAbyssEffect : DestroyAreaOfEffect
{
    public InvincibleAbyssEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new InvincibleAbyssEffect();
    }

    public override string ToString()
    {
        return "Destroy all your opponent's creatures.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(GetOpponent(game).Id);
    }
}
