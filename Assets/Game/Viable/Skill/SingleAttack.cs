using Game.Viable.Core;
using UniRx;

namespace Game.Viable.Skill
{
    public class SingleAttack : SkillObject
    {
        private SingleAttack(
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
        /// <param name="range">範囲</param>
        /// <param name="potency">威力</param>
        /// <returns></returns>
        public static SingleAttack CreateObject(
            int id,
            string name,
            string description,
            float cooldownTime,
            float recastTime,
            BehaviorSubject<float> cooldownTimeSubject,
            float range,
            float potency
        )
        {
            ValidationCheck.CooldownTime(cooldownTime);
            ValidationCheck.RecastTime(recastTime);
            var effect = new Effect(
                type: EffectType.PhysicalAttack,
                target: Target.Enemy,
                range: range,
                potency: potency
            );
            return new SingleAttack(
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