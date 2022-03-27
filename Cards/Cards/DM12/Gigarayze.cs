using Common;
using Engine.Abilities;

namespace Cards.Cards.DM12
{
    class Gigarayze : Creature
    {
        public Gigarayze() : base("Gigarayze", 4, 2000, Subtype.Chimera, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new GigarayzeEffect()));
        }
    }

    class GigarayzeEffect : OneShotEffects.SalvageCivilizationCreatureEffect
    {
        public GigarayzeEffect() : base(0, 1, Civilization.Water, Civilization.Fire)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new GigarayzeEffect();
        }

        public override string ToString()
        {
            return "You may return a water or fire creature from your graveyard to your hand.";
        }
    }
}
