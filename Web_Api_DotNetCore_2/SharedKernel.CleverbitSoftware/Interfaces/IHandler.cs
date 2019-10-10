namespace SharedKernel.CleverbitSoftware.Interfaces
{
    public interface IHandler<in T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}