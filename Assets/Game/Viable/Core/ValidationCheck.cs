using Game.Viable.Exception;

namespace Game.Viable.Core
{
    public class ValidationCheck
    {
        public static void CooldownTime(float cooldownTime)
        {
            if (cooldownTime < Config.CooldownTimeMin || cooldownTime > Config.CooldownTimeMax)
            {
                throw new OutOfRangeException(
                    $"クールダウンタイム(設定:${cooldownTime}秒)は${Config.CooldownTimeMin}-${Config.CooldownTimeMax}秒で設定されている必要があります。"
                );
            }
        }

        public static void RecastTime(float recastTime)
        {
            if (recastTime < Config.RecastTimeMin || recastTime > Config.RecastTimeMax)
            {
                throw new OutOfRangeException(
                    $"リキャストタイム(設定:${recastTime}秒)は${Config.RecastTimeMin}-${Config.RecastTimeMax}秒で設定されている必要があります。"
                );
            }
        }
    }
}