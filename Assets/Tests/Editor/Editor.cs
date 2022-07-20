using System.IO;
using NUnit.Framework;

namespace Tests.Editor
{
    public class AssetTest
    {

        [Test] 
        public void AssetValidate() //name of the test
        {

            var assetDirectoryPath = "Assets/Editor/"; //using this path
            var filePaths = Directory.GetFiles(assetDirectoryPath, "*.cs"); //we are looking for files CS format files

            foreach (var path in filePaths)
            {
                Validate(path); //checking the path of each file
            }
        }

        private void Validate(string path)
        {
            var fileName = Path.GetFileName(path); //collect files' names


            Assert.IsNotNull($"{fileName} => asset is null"); //make sure file names are ok and not null

        }
    }
}