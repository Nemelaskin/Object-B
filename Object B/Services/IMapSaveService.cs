using Object_B.Models;

namespace Object_B.Services
{
    public interface IMapSaveService
    {
        void SaveMapToDataBase(string path, string nameCompany);
        string SaveMapToRelativePath(MapModel uploadedFile, string path);
    }
}