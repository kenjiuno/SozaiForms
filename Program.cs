using PicSozai;
using SozaiForms.Usecases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SozaiForms
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var container = new TinyIoC.TinyIoCContainer())
            {
                container.Register<SplitBitmapUsecase>().AsSingleton();
                container.Register<ExtractIconUsecase>().AsSingleton();
                container.Register<RenderFileToBitmapUsecase>().AsSingleton();
                container.Register<FileListManagerUsecase>().AsSingleton();
                container.Register<LicenseInfoManagerUsecase>().AsSingleton();
                

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(container.Resolve<Form1>());
            }
        }
    }
}
