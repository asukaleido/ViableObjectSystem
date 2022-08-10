using Game.Viable.Core;
using UniRx;

namespace Game.Viable.Skill
{
    public class SelfMedication : SkillObject
    {
        private SelfMedication(
            int id,
            string name,
            string description,
            float cooldownTime,
            float recastTime,
            BehaviorSubject<float> cooldownTimeSubject,
            IEffect effect
        ) : base(
            id,
            name,
            description,
            cooldownTime,
            recastTime,
            cooldownTimeSubject,
            effect
        )
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
        /// <param name="type">スキルのタイプ</param>
        /// <param name="amount">回復量</param>
        /// <returns>自己回復スキルのインスタンス</returns>
        /// <see cref="EffectType"/>
        public static SelfMedication CreateObject(
            int id,
            string name,
            string description,
            float cooldownTime,
            float recastTime,
            BehaviorSubject<float> cooldownTimeSubject,
            EffectType type,
            float amount
        )
        {
            ValidationCheck.CooldownTime(cooldownTime);
            ValidationCheck.RecastTime(recastTime);
            var effect = new FixedEffect(
                type: type,
                target: Target.Self,
                range: 0f,
                amount: amount
            );
            return new SelfMedication(
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