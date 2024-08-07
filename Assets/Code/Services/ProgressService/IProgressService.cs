using Code.Data;

namespace Code.Services.ProgressService
{
    public interface IProgressService : IService
    {
        Progress Progress { get; set; }
    }
}