﻿using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod.Schematics;
using CalamityMod;
using CalamityMod.Tiles.Abyss;
using System;
using CalRemix.Content.Tiles;
using Terraria.DataStructures;

namespace CalRemix.Core.World
{
    public class IonAltar : ModSystem
    {
        public static void GenerateIonAltar()
        {
            bool dungeonRight = Main.dungeonX > (int)(Main.maxTilesX * 0.5f);
            bool shouldBreak = false;
            int xMin = dungeonRight ? (int)(Main.maxTilesX * 0.66f) : 50;
            int xMax = dungeonRight ? (Main.maxTilesX - 50) : (int)(Main.maxTilesX * 0.33f);
            for (int z = 0; z < 2222; z++)
            {
                if (shouldBreak)
                {
                    break;
                }
                for (int i = xMin; i < xMax; i++)
                {
                    if (shouldBreak)
                    {
                        break;
                    }
                    for (int j = 0; j < Main.maxTilesY / 2; j++)
                    {
                        Tile t = CalamityUtils.ParanoidTileRetrieval(i, j);
                        Tile te = CalamityUtils.ParanoidTileRetrieval(i, j - 1);
                        if (shouldBreak)
                        {
                            break;
                        }
                        if (t != null)
                        {
                            if (t.TileType == ModContent.TileType<SulphurousSand>())
                            {
                                if (Main.rand.NextBool(128))
                                {
                                    // check for tiles above, this is ignored if we are on attempt 50
                                    for (int l = 2; l < 22; l++)
                                    {
                                        Tile above = CalamityUtils.ParanoidTileRetrieval(i, j - l);
                                        if (WorldGen.SolidOrSlopedTile(above) && z < 50)
                                            break;

                                        bool liquidCheck = above.LiquidAmount <= 0;
                                        // If there truly are no dry blocks, increasingly add more wet room
                                        if (z > 100)
                                        {
                                            liquidCheck = above.LiquidAmount <= z * 5;
                                        }
                                        bool _ = false;
                                        SchematicManager.PlaceSchematic<Action<Chest>>("Ion Altar", new Point(i, j), SchematicAnchor.CenterLeft, ref _);
                                        Vector2 schematicSize = new Vector2(RemixSchematics.TileMaps["Ion Altar"].GetLength(0), RemixSchematics.TileMaps["Ion Altar"].GetLength(1));
                                        CalamityUtils.AddProtectedStructure(new Rectangle(i, j, (int)schematicSize.X, (int)schematicSize.Y), 4);
                                        shouldBreak = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (!shouldBreak)
            {
                CalRemix.instance.Logger.Error("Ion Altar failed to generate!");
            }
            shouldBreak = false;
            for (int i = 100; i < Main.maxTilesX - 100; i++)
            {
                if (shouldBreak)
                {
                    break;
                }
                for (int j = 0; j < Main.maxTilesY - 80; j++)
                {
                    Tile t = CalamityUtils.ParanoidTileRetrieval(i, j);

                    if (t.TileFrameX != 0 || t.TileFrameY != 0)
                        continue;
                    if (t.TileType == ModContent.TileType<IonCubePlaced>())
                    {
                        TileEntity.PlaceEntityNet(i, j, ModContent.TileEntityType<IonCubeTE>());
                        shouldBreak = true;
                        break;
                    }
                }
            }
            if (!shouldBreak)
            {
                CalRemix.instance.Logger.Error("Could not place Ion Cube!");
            }
        }
    }
}