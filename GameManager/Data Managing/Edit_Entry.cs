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
    public class Edit_Entry
    {
        public static void Edit(string dataPath, string mainDocFolder)
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
                    Console.Write("Change game name: ");
                    dataImageList[x - 1].GameName = Console.ReadLine();
                    Console.Write("Change playtime: ");
                    dataImageList[x - 1].Playtime = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Change rating: ");
                    dataImageList[x - 1].Rating = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Change playstyle (Cooperative/Solo/MMO/Multiplayer): ");
                    dataImageList[x - 1].Style = Console.ReadLine();
                    Console.Write("Change status (Finished/Playing/Plan to play/Pre-ordered): ");
                    dataImageList[x - 1].Status = Console.ReadLine();

                    Console.WriteLine("Editing data..");
                    Thread.Sleep(1500);

                    string json = JsonConvert.SerializeObject(dataImageList);
                    File.WriteAllText(dataPath, json);
                    
                    Console.WriteLine("Data edited on line: " + userInputId);
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
        }
    }
}
