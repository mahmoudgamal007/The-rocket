using TheRocket.Shared;

namespace TheRocket.RepoInterfaces
{
    public interface IImageRepo
    {
         public SharedResponse<object> Upload(List<IFormFile>? files,string folderName,string pathToSave);
    }
}