﻿#define DEV_MODE

using System;

namespace Lunar.Client
{
    public static class Constants
    {
        public static readonly string FILEPATH_ROOT = "Data/";
        public static readonly string FILEPATH_GFX = FILEPATH_ROOT + "gfx/";
        public static readonly string FILEPATH_SFX = FILEPATH_ROOT + "sfx/";
        public static readonly string FILEPATH_MUSIC = FILEPATH_ROOT + "music/";

        public static readonly string FILEPATH_DIRECTORY = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string FILEPATH_DATA = FILEPATH_DIRECTORY + "/" + FILEPATH_ROOT;
        public static readonly string FILEPATH_PLUGINS = FILEPATH_DATA + "/plugins/";
        public static readonly string FILEPATH_SHADERS = FILEPATH_DATA + "/shaders/";


        public const string SERVER_IP = "localhost";

        public const int SERVER_PORT = 25566;

        public const string GAME_NAME = "Lunar Engine";

        public const int CLICK_TIMER_DELAY = 500;

        public const int TILE_WIDTH = 32;
        public const int TILE_HEIGHT = 32;

        public const int MAX_INVENTORY = 30;

        public const int INVENTORY_OFFSET_X = 40;
        public const int INVENTORY_OFFSET_Y = 50;

        public const int INV_SLOT_OFFSET = 68;

        public const int RESOLUTION_X = 1280;
        public const int RESOLUTION_Y = 720;

        public const int DIALOGUE_SEP_X = 20;

        /// <summary>
        /// Minimum amount of time that the loading screen should display
        /// </summary>
        public const long MIN_LOAD_TIME = 1000;
    }
}