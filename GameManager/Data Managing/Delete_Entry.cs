using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using GameManager.Data_Managing;
using GameManager.ClassDEF;
using System.Threading;

namespace GameManager.Data_Managing
{
    public class Delete_Entry
    {
        public static void RemoveRow(string dataPath, string mainDocFolder)
        {
            Show_Entries.ShowEntries(dataPath, mainDocFolder);

            List<DataImage> dataImageList = new List<DataImage>();
            dataImageList = JsonConvert.DeserializeObject<List<DataImage>>(File.ReadAllText(dataPath));

            Console.WriteLine("");
            Console.Write("Choose row: ");
            string userInputId = Console.ReadLine();

            for (int x = 0; x <= dataImageList.Count; x++)
            {
                if (x.ToString() == userInputId)
                {
                    dataImageList.RemoveAt(x - 1);
                    
                    string json = JsonConvert.SerializeObject(dataImageList);
                    File.WriteAllText(dataPath, json);

                    Console.Clear();

                    Console.WriteLine("Deleted row: " + userInputId);
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
        }

        public static void RemoveAll(string dataPath, string mainDocFolder)
        {
            List<DataImage> dataImageList = new List<DataImage>();
            dataImageList = JsonConvert.DeserializeObject<List<DataImage>>(File.ReadAllText(dataPath));

            Console.WriteLine("Clearing..");
            Thread.Sleep(800);
            dataImageList.Clear();

            Console.WriteLine("List was cleared");
            Thread.Sleep(1500);

            Console.Clear();
            
            string json = JsonConvert.SerializeObject(dataImageList);
            File.WriteAllText(dataPath, json);

        }
    }
}
