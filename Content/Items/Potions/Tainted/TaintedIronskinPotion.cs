﻿using CalamityMod;
using CalamityMod.Items.Potions;
using CalRemix.Content.Buffs.Tainted;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalRemix.Content.Items.Potions.Tainted
{
    public class TaintedIronskinPotion : TaintedPotion
    {
        public override int BuffType => ModContent.BuffType<TaintedIronskinBuff>();
        public override int BuffTime => ContentSamples.ItemsByType[PotionType].buffTime;
        public override int PotionType => ItemID.IronskinPotion;
        public override int MeatAmount => 3;
        public override string PotionName => "Ironskin";
    }
}