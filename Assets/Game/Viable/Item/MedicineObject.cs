using Game.Viable.Core;
using UniRx;

namespace Game.Viable.Item
{
    /// <summary>
    /// 薬
    /// </summary>
    public class MedicineObject : InstantItemObject
    {
        private MedicineObject(
            int id,
            string name,
            string description,
            float cooldownTime,
            float recastTime,
            BehaviorSubject<float> cooldownTimeSubject,
            Effect effect
        ) : base(id, name, description, cooldownTime, recastTime, cooldownTimeSubject, effect)
        {
        }

        /// <summary>
        /// インスタンス生成
        /// </summary>
        /// <param name="id">固有識別子</param>
        /// <param name="name">名前</param>
        /// <param name="description">説明文</param>
        /// <param name="cooldownTime">クールダウンタイム(1-6秒)</param>
        /// <param name="recastTime">リキャストタイム(1-180秒)</param>
        /// <param name="cooldownTimeSubject">クールダウンタイム購読インスタンス</param>
        /// <param name="potency">回復力</param>
        /// <returns>薬のインスタンス</returns>
        public static MedicineObject CreateObject(
            int id,
            string name,
            string description,
            float cooldownTime,
            float recastTime,
            BehaviorSubject<float> cooldownTimeSubject,
            float potency
        )
        {
            ValidationCheck.CooldownTime(cooldownTime);
            ValidationCheck.RecastTime(recastTime);
            var effect = new Effect(
                type: EffectType.HpRecovery,
                target: Target.Self,
                range: 0f,
                potency: potency
            );
            return new MedicineObject(
                id,
                name,
                description,
                cooldownTime,
                recastTime,
                cooldownTimeSubject,
                effect
            );
        }
    }
}