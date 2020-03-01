namespace ErisLib.Game.Interfaces
{
    public interface IStructure<IDType> {
        string Name { get; }
        IDType ID { get; }
    }
}