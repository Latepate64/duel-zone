using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM04;

public class MissileBoy : Creature
{
    public MissileBoy() : base("Missile Boy", 3, 1000, Race.Human, Civilization.Fire)
    {
        AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(1, Civilization.Light));
    }
}
