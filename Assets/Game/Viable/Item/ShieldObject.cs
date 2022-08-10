using System.Collections.Generic;
using Game.Status;
using Game.Viable.Core;
using UniRx;

namespace Game.Viable.Item
{
    /// <summary>
    /// 盾
    /// </summary>
    public class ShieldObject : EquipmentItemObject
    {
        public override EquipmentType EquipmentType => EquipmentType.LeftHand;
        public override StatusParameter StatusParameter { get; }

        private ShieldObject(
            int id,
            string name,
            string description,
            float cooldownTime,
            float recastTime,
            BehaviorSubject<float> cooldownTimeSubject,
            float defense,
            List<SkillObject> skillList
        ) : base(id, name, description, cooldownTime, recastTime, cooldownTimeSubject, skillList)
        {
            StatusParameter = new StatusParameter(a: 0f, v: 0f, d: defense, i: 0f);
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
        /// <param name="defense">防御力</param>
        /// <param name="skillList">スキルリスト</param>
        /// <returns>盾のインスタンス</returns>
        public static ShieldObject CreateObject(
            int id,
            string name,
            string description,
            float cooldownTime,
            float recastTime,
            BehaviorSubject<float> cooldownTimeSubject,
            float defense,
            List<SkillObject> skillList
        )
        {
            ValidationCheck.CooldownTime(cooldownTime);
            ValidationCheck.RecastTime(recastTime);
            return new ShieldObject(
                id,
                name,
                description,
                cooldownTime,
                recastTime,
                cooldownTimeSubject,
                defense,
                skillList
            );
        }
    }
}