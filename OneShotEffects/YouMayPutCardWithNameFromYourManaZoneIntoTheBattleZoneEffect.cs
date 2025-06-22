using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect :
    CardMovingChoiceEffect<ICreature>
{
    private readonly string _name;

    YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(
        YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect effect) : base(effect)
    {
        _name = effect._name;
    }

    public YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(string name) : base(
        0, 1, true, ZoneType.ManaZone, ZoneType.BattleZone)
    {
        _name = name;
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(this);
    }

    public override string ToString()
    {
        return $"You may choose an {_name} in your mana zone and put it into the battle zone.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.ManaZone.CardsWithName(_name).OfType<ICreature>();
    }
}
