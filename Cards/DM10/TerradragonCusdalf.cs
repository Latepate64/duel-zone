using ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.DM10
{
    class TerradragonCusdalf : Creature
    {
        public TerradragonCusdalf() : base("Terradragon Cusdalf", 5, 7000, Race.EarthDragon, Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000));
            AddStaticAbilities(new DoubleBreakerEffect());
            AddStaticAbilities(new TerradragonCusdalfEffect());
        }
    }

    class TerradragonCusdalfEffect : ContinuousEffect, IPlayerCannotUntapCardsInManaZoneAtStartOfTurn
    {
        public TerradragonCusdalfEffect()
        {
        }

        public TerradragonCusdalfEffect(IContinuousEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TerradragonCusdalfEffect(this);
        }

        public bool PlayerCannotUntapCardsInManaZoneAtStartOfTurn(Player player)
        {
            return player == Controller;
        }

        public override string ToString()
        {
            return "You can't untap the cards in your mana zone at the start of each of your turns.";
        }
    }
}
