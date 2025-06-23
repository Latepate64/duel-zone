using Engine.Abilities;
using Interfaces;
using OneShotEffects;
using System.Collections.Generic;

namespace OneShotEffects;

public sealed class EnchantedSoilEffect : FromGraveyardIntoManaZoneEffect
{
    public EnchantedSoilEffect() : base(0, 2, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new EnchantedSoilEffect();
    }

    public override string ToString()
    {
        return "Put up to 2 creatures from your graveyard into your mana zone.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.Graveyard.Creatures;
    }
}
