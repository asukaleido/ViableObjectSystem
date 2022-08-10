using UniRx;

namespace Game.Viable.Core
{
    public abstract class ViableObject : IViableObject
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public float CooldownTime { get; }
        public float RecastTime { get; }

        /// <summary>
        /// 現在のクールダウンタイムを通知する
        /// </summary>
        private BehaviorSubject<float> CooldownTimeSubject { get; }

        /// <summary>
        /// 現在のリキャストタイムを通知する
        /// </summary>
        private BehaviorSubject<float> RecastTimeSubject { get; }

        protected ViableObject(
            int id,
            string name,
            string description,
            float cooldownTime,
            float recastTime,
            BehaviorSubject<float> cooldownTimeSubject
        )
        {
            Id = id;
            Name = name;
            Description = description;
            CooldownTime = cooldownTime;
            RecastTime = recastTime;
            CooldownTimeSubject = cooldownTimeSubject;
            RecastTimeSubject = new BehaviorSubject<float>(0f);
        }

        protected virtual bool IsViable()
        {
            return CooldownTimeSubject.Value == 0f && RecastTimeSubject.Value == 0f;
        }

        public virtual void Action()
        {
            if (!IsViable()) return;
            StartRecastTimer();
        }

        private void StartRecastTimer()
        {
            // TODO リキャストタイマーの実装
            throw new System.NotImplementedException();
        }
    }
}