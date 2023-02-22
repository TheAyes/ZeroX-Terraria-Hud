using Terraria.ModLoader;
using ZeroXHUD.Core;

namespace ZeroXHUD
{
    public class ZeroXhud : Mod
    {
        public static ZeroXhudSystem ModSystemInstance { get; private set; }

        public static void InitializeModSystem(ZeroXhudSystem modSystem)
        {
            ModSystemInstance = modSystem;
        }

        public static void InitializeModPlayer(ZeroXPlayer modPlayer)
        {
        }
    }
}