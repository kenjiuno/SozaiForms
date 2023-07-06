using SozaiForms.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SozaiForms.Usecases
{
    public class LicenseInfoManagerUsecase
    {
        private readonly string _file;
        private readonly XmlSerializer _xs;

        public LicenseInfoManagerUsecase()
        {
            _file = Path.Combine(Application.StartupPath, "LicenseInfo.bin");
            _xs = new XmlSerializer(typeof(List<LicenseInfo>));
        }

        public List<LicenseInfo> TryToLoadFromCache()
        {
            if (File.Exists(_file))
            {
                return (List<LicenseInfo>)_xs.Deserialize(
                    new MemoryStream(
                        File.ReadAllBytes(_file)
                    )
                );
            }
            else
            {
                return null;
            }
        }

        public List<LicenseInfo> CreateFromAndSaveCache(string[] dirs)
        {
            var licenses = new List<LicenseInfo>();

            foreach (var dir in dirs)
            {
                foreach (string fp in Directory.GetFiles(dir, "@*"))
                {
                    licenses.Add(
                        new LicenseInfo
                        {
                            Dir = dir,
                            License = Path.GetFileName(fp)
                        }
                    );
                }
            }

            using (var stream = File.Create(_file))
            {
                _xs.Serialize(stream, licenses);
            }

            return licenses;
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
