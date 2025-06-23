using ContinuousEffects;
using Interfaces;

namespace Cards.DM01;

public sealed class Tropico : Creature
{
    public Tropico() : base("Tropico", 5, 3000, Race.CyberLord, Civilization.Water)
    {
        AddStaticAbilities(new TropicoEffect());
    }
}
