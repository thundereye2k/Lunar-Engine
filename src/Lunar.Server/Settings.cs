﻿/** Copyright 2018 John Lamontagne https://www.mmorpgcreation.com

	Licensed under the Apache License, Version 2.0 (the "License");
	you may not use this file except in compliance with the License.
	You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

	Unless required by applicable law or agreed to in writing, software
	distributed under the License is distributed on an "AS IS" BASIS,
	WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	See the License for the specific language governing permissions and
	limitations under the License.
*/
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace Lunar.Server
{
    public static class Settings
    {
        private static readonly string _filePath = Constants.FILEPATH_DATA + "config.xml";

        public static string GameName { get; private set; }

        public static int ServerPort { get; private set; }

        public static string WelcomeMessage { get; private set; }

        public static string StartingMap { get; private set; }

        public static int MaxInventoryItems { get; private set; }

        public static int TickRate { get; private set; }

        public static int TileSize { get; private set; }

        public static int NPCRestPeriod { get; private set; }

        public static int MapItemWidth { get; private set; }

        public static int MapItemHeight { get; private set; }

        public static void Initalize()
        {
            LoadConfig();
        }

        private static void CreateConfig()
        {
            var xml = new XElement("Config",
                new XElement("General",
                    new XElement("Port", 25566),
                    new XElement("Game_Name", "Lunar Engine"),
                    new XElement("Welcome_Message", "Welcome to Lunar Engine!")
                ),
                new XElement("Gameplay",
                    new XElement("Starting_Map", "default"),
                    new XElement("Max_Inventory_Slots", 30),
                    new XElement("NPC_Rest_Period", 400)
                ),
                new XElement("Advanced", 
                    new XElement("Tick_Rate", 60),
                    new XElement("Tile_Size", 32),
                    new XElement("Map_Item_Width", 32),
                    new XElement("Map_Item_Height", 32)
                )               
            );
            xml.Save(_filePath);
        }

        private static void LoadConfig()
        {
            if (!File.Exists(_filePath))
                CreateConfig();

            try
            {
                var doc = XDocument.Load(_filePath);

                var generalSettings = doc.Elements("Config").Elements("General");
                Settings.ServerPort = int.Parse(generalSettings.Elements("Port").FirstOrDefault().Value);
                Settings.GameName = generalSettings.Elements("Game_Name").FirstOrDefault().Value;
                Settings.WelcomeMessage = generalSettings.Elements("Welcome_Message").FirstOrDefault().Value;

                var gameplaySettings = doc.Elements("Config").Elements("Gameplay");
                Settings.StartingMap = gameplaySettings.Elements("Starting_Map").FirstOrDefault().Value;
                Settings.MaxInventoryItems = int.Parse(gameplaySettings.Elements("Max_Inventory_Slots").FirstOrDefault().Value);
                Settings.NPCRestPeriod = int.Parse(gameplaySettings.Elements("NPC_Rest_Period").FirstOrDefault().Value);

                var advancedSettings = doc.Elements("Config").Elements("Advanced");
                Settings.TickRate = int.Parse(advancedSettings.Elements("Tick_Rate").FirstOrDefault().Value);
                Settings.TileSize = int.Parse(advancedSettings.Elements("Tile_Size").FirstOrDefault().Value);
                Settings.MapItemWidth = int.Parse(advancedSettings.Elements("Map_Item_Width").FirstOrDefault().Value);
                Settings.MapItemHeight = int.Parse(advancedSettings.Elements("Map_Item_Height").FirstOrDefault().Value);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("The server config file appears to be corrupted!");
                Console.Write("Would you like to restore the configuration to its original state? [y/n]");

                if (Console.ReadLine() == "y")
                {
                    CreateConfig();
                }
                else
                {
                    Console.WriteLine("Terminating server...");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }
            }

        }
    }
}