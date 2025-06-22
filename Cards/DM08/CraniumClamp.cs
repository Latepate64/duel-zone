using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

public sealed class CraniumClamp : Spell
{
    public CraniumClamp() : base("Cranium Clamp", 4, Civilization.Darkness)
    {
        AddSpellAbilities(new YourOpponentChoosesAndDiscardsCardsFromHisHandEffect(2));
    }
}