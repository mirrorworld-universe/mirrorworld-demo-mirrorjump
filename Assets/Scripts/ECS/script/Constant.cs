

    public static class Constant
    {   
        
        
        //Theme 
        public static int ThemeSpaceIndex = 0;
        public static int ThemeDesertIndex = 1;
        public static int ThemeSnowIndex = 2;
        public static int ThemeCyberpunkIndex = 3;
        
        
        //Rarity
        public static string Common = "Common";
        public static string Rare = "Rare";
        public static string Elite = "Elite";
        public static string Legendary = "Legendary";
        public static string Mythical =  "Mythical";
        
        
        // Role
        public static string CatMaid = "Cat Maid";

        public static string Samurai = "Samurai";
        
        public static string Zombie = "Zombie";

        public static string PirateCaptain = "Pirate Captain";
        
        public static string Astronaut=  "Astronaut";
        
        
        // url
        public static string ImagePrefix = "http://metadata-assets.mirrorworld.fun/mirror_jump/images/";
        

        public static string GetAstronautUrlByRarity(string rarity)
        {
            return ImagePrefix + rarity + Astronaut + ".png";
        }
        
        public static string GetPirateCaptainUrlByRarity(string rarity)
        {
            return ImagePrefix + rarity + PirateCaptain + ".png";
        }
        
        public static string GetZombieUrlByRarity(string rarity)
        {
            return ImagePrefix + rarity + Zombie + ".png";
        }
        
        public static string GetSamuraiUrlByRarity(string rarity)
        {
            return ImagePrefix + rarity +Samurai + ".png";
        }
        
        public static string GetCatMaidUrlByRarity(string rarity)
        {
            return ImagePrefix + rarity + CatMaid + ".png";
        }
        
    }
