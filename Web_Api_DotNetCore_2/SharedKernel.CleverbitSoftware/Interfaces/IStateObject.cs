using SharedKernel.CleverbitSoftware.Enums;

namespace SharedKernel.CleverbitSoftware.Interfaces
{
    public interface IStateObject
    {
        ObjectState State { get; }
    }
}