using System;
using System.Collections.Generic;
using System.Text;
using GameManager.ClassDEF;
using Newtonsoft.Json;
using System.IO;

namespace GameManager.Data_Managing
{
    public class Show_Entries
    {
        public static void ShowEntries(string dataPath, string mainDocFolder)
        {
            int totalPlaytime = 0;
            float averageRating = 0;

            int finishedCounter = 0;
            int playingCounter = 0;
            int preorderCounter = 0;
            int plantoplayCounter = 0;

            int limitCounter = 0;

            int coopCounter = 0;
            int soloCounter = 0;
            int mmoCounter = 0;
            int multiplayerCounter = 0;

            Console.Clear();

            int entryCounter = 1;
            List<DataImage> dataImageList = new List<DataImage>();

            dataImageList = JsonConvert.DeserializeObject<List<DataImage>>(File.ReadAllText(dataPath));

            Console.WriteLine("");

            foreach (var iterate in dataImageList)
            {
                Console.Write(entryCounter + " | ");
                Console.WriteLine(iterate.GameName + " | " + iterate.Playtime + "H" + " | " + iterate.Rating + "/10 | " + "Playstyle: " + iterate.Style + " | Gamestatus: " + iterate.Status);

                if (iterate.Status == "Finished")
                {
                    totalPlaytime += Convert.ToInt32(iterate.Playtime);
                    averageRating += Convert.ToInt32(iterate.Rating);

                    limitCounter += 1;
                }
                if (iterate.Status == "Playing")
                {
                    totalPlaytime += Convert.ToInt32(iterate.Playtime);
                    averageRating += Convert.ToInt32(iterate.Rating);

                    limitCounter += 1;
                }

                if (iterate.Status == "Playing")
                {
                    playingCounter += 1;
                }
                if (iterate.Status == "Pre-ordered")
                {
                    preorderCounter += 1;
                }
                if (iterate.Status == "Finished")
                {
                    finishedCounter += 1;
                }
                if (iterate.Status == "Plan to play")
                {
                    plantoplayCounter += 1;
                }


                if (iterate.Style == "Cooperative")
                {
                    coopCounter += 1;
                }
                if (iterate.Style == "Solo")
                {
                    soloCounter += 1;
                }
                if (iterate.Style == "MMO")
                {
                    mmoCounter += 1;
                }
                if (iterate.Style == "Multiplayer")
                {
                    multiplayerCounter += 1;
                }

                entryCounter += 1;
            }

            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.Write("        All games >> " + dataImageList.Count);
            Console.Write("        Total playtime >> " + totalPlaytime + "H");
            Console.WriteLine("        Average rating >> " + Math.Round(averageRating / limitCounter, 2));
            Console.WriteLine("-------------------------------------------------------------------------------------------------");

            Console.Write("   Finished games >> " + finishedCounter);
            Console.Write(" | Playing now >> " + playingCounter);
            Console.Write(" | Plan to play games >> " + plantoplayCounter);
            Console.WriteLine(" | Pre-ordered games >> " + preorderCounter);
            Console.WriteLine("-------------------------------------------------------------------------------------------------");

            Console.Write("   Cooperative games >> " + coopCounter);
            Console.Write(" | Solo games >> " + soloCounter);
            Console.Write(" | MMO games >> " + mmoCounter);
            Console.WriteLine(" | Multiplayer games >> " + multiplayerCounter);
            Console.WriteLine("-------------------------------------------------------------------------------------------------");

            Console.WriteLine("");

            entryCounter = 1;
        }
    }
}
