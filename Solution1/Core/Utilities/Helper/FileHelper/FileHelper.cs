

using Microsoft.AspNetCore.Http;

namespace Core
{
    public class FileHelper : IFileHelper
    {
        public object Messaages { get; private set; }
        public object Messages { get; private set; }

        public string Add(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
            var imagePath = FilePath.Full(uniqueFileName);
            using FileStream fileStream = new FileStream(imagePath, FileMode.Create);
            file.CopyTo(fileStream);
            fileStream.Flush();
            return uniqueFileName;
        }

        public void Delete(string path)
        {
            if (Path.Exists(FilePath.Full(path)))
            {
                File.Delete(FilePath.Full(path));
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }

        public void Update(IFormFile file, string imagePath)
        {
            var fullPath = FilePath.Full(imagePath);
            if (Path.Exists(fullPath))
            {
                using FileStream fileStream = new FileStream(fullPath, FileMode.Create);
                file.CopyTo((fileStream));
                fileStream.Flush();
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }
    }
}
