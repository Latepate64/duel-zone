using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM09
{
    sealed class NecrodragonIzoristVhal : Creature
    {
        public NecrodragonIzoristVhal() : base("Necrodragon Izorist Vhal", 6, 0, Race.ZombieDragon, Civilization.Darkness)
        {
            AddStaticAbilities(new NecrodragonIzoristVhalEffect(), new PoweredDoubleBreaker());
        }
    }

    sealed class NecrodragonIzoristVhalEffect(int power = 2000) : PowerModifyingMultiplierEffect(power)
    {
        public override IContinuousEffect Copy()
        {
            return new NecrodragonIzoristVhalEffect();
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each darkness creature in your graveyard.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return Controller.Graveyard.GetCreatureCount(Civilization.Darkness);
        }
    }
}
