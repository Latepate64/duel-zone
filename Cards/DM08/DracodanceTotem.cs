using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM08;

sealed class DracodanceTotem : Creature
{
    public DracodanceTotem() : base("Dracodance Totem", 2, 1000, Race.MysteryTotem, Civilization.Nature)
    {
        AddStaticAbilities(new DracodanceTotemEffect());
    }
}
