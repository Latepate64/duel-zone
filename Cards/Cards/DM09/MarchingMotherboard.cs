using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM09
{
    class MarchingMotherboard : Creature
    {
        public MarchingMotherboard() : base("Marching Motherboard", 6, 2000, Race.CyberVirus, Civilization.Water)
        {
            AddTriggeredAbility(new MarchingMotherboardAbility(new OneShotEffects.YouMayDrawCardEffect()));
        }
    }

    class MarchingMotherboardAbility : WheneverCreatureIsPutIntoTheBattleZoneAbility
    {
        public MarchingMotherboardAbility(MarchingMotherboardAbility ability) : base(ability)
        {
        }

        public MarchingMotherboardAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public override IAbility Copy()
        {
            return new MarchingMotherboardAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever you put another creature that has Cyber in its race into the battle zone, {GetEffectText()}";
        }

        protected override bool TriggersFrom(ICard card, IGame game)
        {
            return card.Owner == ControllerPlayer && card != Source && card.Races.Intersect(new Race[] { Race.CyberCluster, Race.CyberLord, Race.CyberMoon, Race.CyberVirus }).Any();
        }
    }
}
