using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public class YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect : ManaFeedEffect
{
    public YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect() : base(1, 1, false)
    {
    }

    public YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect(
        YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect effect) : base(
            effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YourOpponentChoosesOneOfHisCreaturesInTheBattleZoneAndPutsItIntoHisManaZoneEffect(this);
    }

    public override string ToString()
    {
        return "Your opponent chooses one of his creatures in the battle zone and puts it into his mana zone.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(GetOpponent(game).Id);
    }
}
