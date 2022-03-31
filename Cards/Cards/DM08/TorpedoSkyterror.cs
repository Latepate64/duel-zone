using Common;

namespace Cards.Cards.DM08
{
    class TorpedoSkyterror : Creature
    {
        public TorpedoSkyterror() : base("Torpedo Skyterror", 5, 4000, Subtype.ArmoredWyvern, Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.DogarnTheMarauderEffect());
        }
    }
}
