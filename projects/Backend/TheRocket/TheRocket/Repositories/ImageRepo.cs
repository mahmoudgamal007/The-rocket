using System.Net.Http.Headers;
using TheRocket.RepoInterfaces;
using TheRocket.Shared;

namespace TheRocket.Repositories
{
    public class ImageRepo : IImageRepo
    {
        public SharedResponse<object> Upload(List<IFormFile> files, string folderName, string pathToSave)
        {
            try
            {
                foreach (var file in files)
                    if (!(file.Length > 0))
                        return new SharedResponse<object>(Status.badRequest, null);

                List<string> paths = new();
                foreach (var file in files)
                {
                    Guid guid = Guid.NewGuid();
                    var fileName = guid + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fileName = fileName.Replace(" ", "");
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    paths.Add("http://localhost:52437/"+dbPath);
                }
                return new SharedResponse<object>(Status.createdAtAction, new { paths = paths });
            }
            catch (Exception ex)
            {
                return new SharedResponse<object>(Status.expeption, null, ex.ToString());
            }
        }
    }
}