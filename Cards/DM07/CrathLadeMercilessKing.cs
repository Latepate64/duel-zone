using OneShotEffects;
using Engine.Abilities;
using Engine;
using Interfaces;

namespace Cards.DM07;

public sealed class CrathLadeMercilessKing : Creature
{
    public CrathLadeMercilessKing() : base("Crath Lade, Merciless King", 8, 4000, Race.DarkLord, Civilization.Darkness)
    {
        AddAbilities(new TapAbility(new OpponentRandomDiscardEffect(2)));
    }
}
