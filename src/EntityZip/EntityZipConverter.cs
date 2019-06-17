using EntityZip.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace EntityZip
{
    public class EntityZipConverter
    {
        private readonly string Separator;
        public EntityZipConverter(string separator = ",")
        {
            Separator = separator;
        }
        public IDictionary<string, List<string>> FilesDictionary { get; set; } = new Dictionary<string, List<string>>();

        public void ConvertEntityToCSV<T>(T srcEntity, string fileName)
        {
            if (!FilesDictionary.ContainsKey(fileName))
                FilesDictionary.Add(fileName, new List<string>());

            FilesDictionary[fileName].Add(string.Join(Separator, ReflectionHelper.GetHeader(srcEntity)));
            FilesDictionary[fileName].Add(string.Join(Separator, ReflectionHelper.GetValues(srcEntity)));            
        }

        public void ConvertListToCSV<T>(IEnumerable<T> srcEntity, string fileName)
        {
            if (srcEntity.Count() > 0)
            {
                if (!FilesDictionary.ContainsKey(fileName))
                    FilesDictionary.Add(fileName, new List<string>());

                FilesDictionary[fileName].Add(string.Join(Separator, ReflectionHelper.GetHeader(srcEntity.First())));
                foreach (var item in srcEntity)
                {
                    FilesDictionary[fileName].Add(string.Join(Separator, ReflectionHelper.GetValues(item)));
                }                
            }
        }

        public byte[] ConvertToZipBytes()
        {
            using (var outStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true))
                {
                    foreach (var item in FilesDictionary)
                    {
                        var fileInArchive = archive.CreateEntry((item.Key + ".csv"), CompressionLevel.Fastest);
                        using (var entryStream = fileInArchive.Open())
                        using (var fileToCompressStream = new MemoryStream(Encoding.Default.GetBytes(string.Join(Environment.NewLine, item.Value))))
                        {
                            fileToCompressStream.CopyTo(entryStream);
                        }
                    }
                }
                return outStream.ToArray();
            }
        }
    }
}
