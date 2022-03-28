using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class Gigargon : Creature
    {
        public Gigargon() : base("Gigargon", 8, 3000, Common.Subtype.Chimera, Common.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new GigargonEffect());
        }
    }

    class GigargonEffect : OneShotEffects.SalvageCreatureEffect
    {
        public GigargonEffect() : base(0, 2)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new GigargonEffect();
        }

        public override string ToString()
        {
            return "Return up to 2 creatures from your graveyard to your hand.";
        }
    }
}
