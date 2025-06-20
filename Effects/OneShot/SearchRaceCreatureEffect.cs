using Engine;
using Engine.Abilities;

namespace Effects.OneShot;

public class SearchRaceCreatureEffect : SearchEffect, IRaceable
{
    public SearchRaceCreatureEffect(Race race) : base(true)
    {
        Race = race;
    }

    public SearchRaceCreatureEffect(SearchRaceCreatureEffect effect) : base(effect)
    {
        Race = effect.Race;
    }

    public Race Race { get; }

    public override IOneShotEffect Copy()
    {
        return new SearchRaceCreatureEffect(this);
    }

    public override string ToString()
    {
        return $"When you put this creature into the battle zone, search your deck. You may take a {Race} from your deck, show that {Race} to your opponent, and put it into your hand. Then shuffle your deck.";
    }

    protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.Deck.GetCreatures(Race);
    }
}
