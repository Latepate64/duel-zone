using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class PangaeasWillEffect : OneShotEffect
{
    public PangaeasWillEffect()
    {
    }

    public PangaeasWillEffect(PangaeasWillEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var card = Controller.ChooseCard(game.BattleZone.GetChoosableEvolutionCreaturesControlledByPlayer(
            game, GetOpponent(game).Id), ToString());
        if (card != null)
        {
            game.MoveTopCard(card, ZoneType.ManaZone, Ability);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new PangaeasWillEffect(this);
    }

    public override string ToString()
    {
        return "Choose one of your opponent's evolution creatures in the battle zone and put the top card of that creature into your opponent's mana zone.";
    }
}
