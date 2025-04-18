﻿using CalamityMod.Tiles.BaseTiles;
using Terraria.ModLoader;

namespace CalRemix.Content.Tiles.Relics
{
    public class OxygenRelicPlaced : BaseBossRelic
    {
        public override string RelicTextureName => "CalRemix/Content/Tiles/Relics/OxygenRelicPlaced";

        public override int AssociatedItem => ModContent.ItemType<Items.Placeables.Relics.OxygenRelic>();
    }
}
