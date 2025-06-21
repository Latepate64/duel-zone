namespace Engine.Choices
{
    public interface IChoice
    {
        string Description { get; }
        IPlayer Maker { get; }
        
        bool IsValid();
    }
}
