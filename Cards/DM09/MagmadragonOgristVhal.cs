using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM09;

public sealed class MagmadragonOgristVhal : Creature
{
    public MagmadragonOgristVhal() : base("Magmadragon Ogrist Vhal", 7, 3000, Race.VolcanoDragon, Civilization.Fire)
    {
        AddStaticAbilities(new MagmadragonOgristVhalEffect(), new PoweredTripleBreaker());
    }
}
