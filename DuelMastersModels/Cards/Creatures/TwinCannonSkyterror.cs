using DuelMastersModels.Abilities.StaticAbilities;

namespace DuelMastersModels.Cards.Creatures
{
    public class TwinCannonSkyterror : Creature
    {
        public TwinCannonSkyterror() : base(7, Civilization.Fire, 7000, Race.ArmoredWyvern)
        {
            StaticAbilities.Add(new DoubleBreaker(Id));
            StaticAbilities.Add(new SpeedAttacker(Id));
        }

        public TwinCannonSkyterror(Creature creature) : base(creature)
        {
        }

        public override Card Copy()
        {
            return new TwinCannonSkyterror(this);
        }
    }
}
