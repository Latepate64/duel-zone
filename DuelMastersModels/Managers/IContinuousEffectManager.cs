using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using System.Collections.Generic;

namespace DuelMastersModels.Managers
{
    public interface IContinuousEffectManager
    {
        void AddContinuousEffect(IContinuousEffect continuousEffect);
        bool AttacksIfAble(IDuel duel, IAbilityManager abilityManager, IBattleZoneCreature creature);
        void EndContinuousEffects<T>();
        IEnumerable<IBattleZoneCreature> GetAllBlockersPlayerHasInTheBattleZone(IPlayer player, IDuel duel, IAbilityManager abilityManager);
        IEnumerable<IBattleZoneCreature> GetCreaturesThatCannotAttack(IDuel duel, IAbilityManager abilityManager, IPlayer player);
        IEnumerable<IBattleZoneCreature> GetCreaturesThatCannotAttackPlayers(IDuel duel, IAbilityManager abilityManager);
        int GetPower(IDuel duel, IAbilityManager abilityManager, IBattleZoneCreature creature);
        bool HasShieldTrigger(IDuel duel, IAbilityManager abilityManager, IHandCreature creature);
        bool HasShieldTrigger(IDuel duel, IAbilityManager abilityManager, ISpell spell);
        bool HasSpeedAttacker(IDuel duel, IAbilityManager abilityManager, IBattleZoneCreature creature);
    }
}