using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using GameManager.ClassDEF;
using Newtonsoft.Json.Converters;
using System.Threading;

namespace GameManager.Data_Managing
{
    public class Create_Entry
    {
        public static void AddGame(string dataPath)
        {
            string GameName;
            string Rating; //int
            string Playtime; //int
            string Style;
            string Status;

            Console.WriteLine("");
            Console.Write("*Inser game name: ");
            GameName = Console.ReadLine();

            if (GameName == "")
            {
                GameName = "Non-defined";
            }

            Console.WriteLine("");
            Console.Write("*Insert rating out of 10: ");
            Rating = Console.ReadLine();

            if (Rating == "")
            {
                Rating = "0";
            }

            Console.WriteLine("");
            Console.Write("Insert playtime: ");
            Playtime = Console.ReadLine();

            if (Playtime == "")
            {
                Playtime = "0";
            }

            Console.WriteLine("");
            Console.Write("Insert playstyle (Cooperative/Solo/MMO/Multiplayer): ");
            Style = Console.ReadLine();

            if (Style == "")
            {
                Style = "Non-defined";
            }

            Console.WriteLine("");
            Console.Write("Insert status (Finished/Playing/Plan to play/Pre-ordered): ");
            Status = Console.ReadLine();

            if (Status == "")
            {
                Status = "Non-defined";
            }

            Console.Clear();
            Console.WriteLine("Game " + GameName + " entry was saved!");
            Thread.Sleep(1500);
            Console.Clear();

            DataImage dataImage = new DataImage();

            Save(dataPath, GameName, Rating, Playtime, Style, Status);
        }

        static void Save(string dataPath, string GameName, string Rating, string Playtime, string Style, string Status)
        {
            List<DataImage> dataImageList = new List<DataImage>();
            DataImage dataImage = new DataImage();

            string json;

            if (new FileInfo(dataPath).Length == 0)
            {
                //Console.WriteLine("File's empty");

                dataImage.GameName = GameName;
                dataImage.Rating = Convert.ToInt32(Rating);
                dataImage.Playtime = Convert.ToInt32(Playtime);
                dataImage.Style = Style;
                dataImage.Status = Status;

                dataImageList.Add(dataImage);

                json = JsonConvert.SerializeObject(dataImageList);
                File.WriteAllText(dataPath, json);
            }
            else
            {
                //Console.WriteLine("File's not empty");

                dataImage.GameName = GameName;
                dataImage.Rating = Convert.ToInt32(Rating);
                dataImage.Playtime = Convert.ToInt32(Playtime);
                dataImage.Style = Style;
                dataImage.Status = Status;

                dataImageList = JsonConvert.DeserializeObject<List<DataImage>>(File.ReadAllText(dataPath));
                dataImageList.Add(dataImage);

                json = JsonConvert.SerializeObject(dataImageList);
                File.WriteAllText(dataPath, json);
            }
        }
    }
}
