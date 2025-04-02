using Terraria;
using Terraria.ModLoader;

namespace CalRemix.Content.Buffs
{
    public class MysticDischarge : ModBuff
    {
        public static float MultiplicativeDamageReductionPlayer = 0.9f;
        public static float MultiplicativeDamageReductionEnemy = 0.9f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mystic Discharge");
            Description.SetDefault("We have no idea why you are taking damage, How MYSTical.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.Remix().mysticDischarge < npc.buffTime[buffIndex])
                npc.Remix().mysticDischarge = npc.buffTime[buffIndex];
            npc.DelBuff(buffIndex);
            buffIndex--;
        }
    }
