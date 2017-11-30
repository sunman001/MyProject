using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphic
{
   public  class LoadManager
   {
       private IList<Files> files = new List<Files>();

       public IList<Files> Files
       {
            get { return files; }
       }

       public void LoadFiles(Files file)
       {
           files.Add(file);
       }



       public void OpenAllFiles()
       {
           foreach (IFileOpen file in files)
           {
               file.Open();
           }
       }

       public void OpenFile(IFileOpen file)
       {
           file.Open();
       }

       public FileType GeTFileType(string fileName)
       {
           FileInfo fi = new FileInfo(fileName);
           return (FileType) Enum.Parse(typeof(FileType), fi.Extension);
       }
   }
}
