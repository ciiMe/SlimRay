using System.IO;

namespace SlimRay.Utils.Files
{
    public class FileHelper
    {
        public void Delete(string fileName, bool isIncludeReadOnly = true)
        {
            if (!File.Exists(fileName))
            {
                return;
            }

            if (isIncludeReadOnly)
            {
                File.SetAttributes(fileName, FileAttributes.Normal);
            }

            File.Delete(fileName);
        }
    }
}
