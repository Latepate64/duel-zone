using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using System.Collections.Generic;

namespace DuelMastersModels.Managers
{
    public interface IContinuousEffectManager
    {
        IDuel Duel { get; set; }
        IAbilityManager AbilityManager { get; set; }

        void AddContinuousEffect(IContinuousEffect continuousEffect);
        bool AttacksIfAble(IBattleZoneCreature creature);
        void EndContinuousEffects<T>();
        IEnumerable<IBattleZoneCreature> GetAllBlockersPlayerHasInTheBattleZone(IPlayer player);
        IEnumerable<IBattleZoneCreature> GetCreaturesThatCannotAttack(IPlayer player);
        IEnumerable<IBattleZoneCreature> GetCreaturesThatCannotAttackPlayers();
        int GetPower(IBattleZoneCreature creature);
        bool HasShieldTrigger(IHandCreature creature);
        bool HasShieldTrigger(ISpell spell);
        bool HasSpeedAttacker(IBattleZoneCreature creature);
    }
}