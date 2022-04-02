using Cards.ContinuousEffects;
using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM09
{
    class NecrodragonIzoristVhal : Creature
    {
        public NecrodragonIzoristVhal() : base("Necrodragon Izorist Vhal", 6, 0, Subtype.ZombieDragon, Civilization.Darkness)
        {
            AddStaticAbilities(new NecrodragonIzoristVhalEffect(), new PoweredDoubleBreaker());
        }
    }

    class NecrodragonIzoristVhalEffect : PowerModifyingMultiplierEffect
    {
        public NecrodragonIzoristVhalEffect() : base(2000, new CardFilters.OwnersGraveyardCivilizationCreatureFilter(Civilization.Darkness))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new NecrodragonIzoristVhalEffect();
        }

        public override string ToString()
        {
            return "This creature gets +2000 power for each darkness creature in your graveyard.";
        }
    }
}
