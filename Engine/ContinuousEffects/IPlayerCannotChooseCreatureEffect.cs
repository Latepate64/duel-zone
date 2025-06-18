namespace Engine.ContinuousEffects
{
    public interface IPlayerCannotChooseCreatureEffect : IContinuousEffect
    {
        bool PlayerCannotChooseCreature(Creature creature, System.Guid player, IGame game);
    }
}
