using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows.Forms;

namespace SozaiForms.Usecases
{
    public class FileListManagerUsecase
    {
        private readonly string _file;

        public FileListManagerUsecase()
        {
            _file = Path.Combine(Application.StartupPath, "CACHE.bin");
        }

        public string TryToLoadFromCache()
        {
            if (File.Exists(_file))
            {
                return File.ReadAllText(_file);
            }
            else
            {
                return null;
            }
        }

        public string CreateFileListFromAndSaveCache(string[] dirs)
        {
            var cache = "";
            foreach (var dir in dirs)
            {
                cache = cache + "\n" + string.Join("\n", Directory.GetFiles(dir, "*", SearchOption.AllDirectories));
            }
            File.WriteAllText(_file, cache);
            return cache;
        }

        public bool DeleteCache()
        {
            var fi = new FileInfo(_file);
            if (fi.Exists)
            {
                fi.Delete();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
