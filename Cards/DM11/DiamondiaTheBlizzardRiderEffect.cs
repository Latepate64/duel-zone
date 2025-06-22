using Engine.Abilities;
using Interfaces;

namespace Cards.DM11;

public sealed class DiamondiaTheBlizzardRiderEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        game.Move(Ability, ZoneType.Graveyard, ZoneType.Hand, [.. Controller.Graveyard.GetCreatures(Race.SnowFaerie)]);
        game.Move(Ability, ZoneType.ManaZone, ZoneType.Hand, [.. Controller.ManaZone.GetCreatures(Race.SnowFaerie)]);
    }

    public override IOneShotEffect Copy()
    {
        return new DiamondiaTheBlizzardRiderEffect();
    }

    public override string ToString()
    {
        return "Return all Snow Faeries from your graveyard and your mana zone to your hand.";
    }
}
