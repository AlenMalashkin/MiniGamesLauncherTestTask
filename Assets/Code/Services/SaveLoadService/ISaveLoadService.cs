using System.Threading.Tasks;
using Code.Data;

namespace Code.Services.SaveLoadService
{
    public interface ISaveLoadService : IService
    {
        void SaveData();
        Task<Progress> LoadData();
    }
}