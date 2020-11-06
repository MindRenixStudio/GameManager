using System;
using System.Collections.Generic;
using System.Text;
using GameManager.ClassDEF;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace GameManager.Data_Managing
{
    public class ExportJSON_To_TXT
    {
        public static void ExportToTxt(string dataPath, string mainDocFolder)
        {
            string fileName = "GameManager_Export.txt";
            string exportLocation = Path.Combine(mainDocFolder, fileName);

            if (File.Exists(Path.Combine(mainDocFolder, fileName)))
            {
                File.Delete(Path.Combine(mainDocFolder, fileName));
                Console.WriteLine(">> Previous export deleted");
                Console.WriteLine("");
            }

            List<DataImage> dataImageList = new List<DataImage>();
            dataImageList = JsonConvert.DeserializeObject<List<DataImage>>(File.ReadAllText(dataPath));

            Console.WriteLine("Data loaded..");
            Thread.Sleep(1000);
            Console.WriteLine("Converting to txt..");
            Thread.Sleep(1000);
            Console.WriteLine("Converted to GameManager_Export.txt");
            Thread.Sleep(1000);
            Console.WriteLine("");

            for (int iteration = 0; iteration < dataImageList.Count; iteration++)
            {
                using (StreamWriter file = new StreamWriter(exportLocation, true))
                {
                    file.WriteLine(dataImageList[iteration].GameName + " ─ Playtime: " + dataImageList[iteration].Playtime + "h ─ Rating: " + dataImageList[iteration].Rating + "/10 ─ " + dataImageList[iteration].Style + " ─ " + dataImageList[iteration].Status);
                    file.WriteLine("──────────────────────────────────────────────────────────────────────────────────────────");
                }
            }
        }
    }
}
