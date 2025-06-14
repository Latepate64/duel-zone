namespace Engine.Choices
{
    public interface IChoice
    {
        string Description { get; }
        Player Maker { get; }
        
        bool IsValid();
    }
}
