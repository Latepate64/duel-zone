using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using OneShotEffects;

namespace OneShotEffects;

public sealed class GigarayzeEffect : SalvageCivilizationCreatureEffect
{
    readonly Civilization[] civilizations;

    public GigarayzeEffect(params Civilization[] civilizations) : base(0, 1)
    {
        this.civilizations = civilizations;
    }

    GigarayzeEffect(GigarayzeEffect effect) : base(effect)
    {
        civilizations = [..effect.civilizations];
    }

    public override IOneShotEffect Copy()
    {
        return new GigarayzeEffect(this);
    }

    public override string ToString()
    {
        return $"You may return a {string.Join(" or ", civilizations)} creature from your graveyard to your hand.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.Graveyard.Creatures.Where(x => x.HasCivilization(Civilization.Water, Civilization.Fire));
    }
}
