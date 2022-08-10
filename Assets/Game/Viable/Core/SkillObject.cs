using System;
using UniRx;

namespace Game.Viable.Core
{
    /// <summary>
    /// 影響を及ぼす実行可能オブジェクトでスキルに該当するもの
    /// </summary>
    public abstract class SkillObject : ViableObject, IEffectiveObject
    {
        private readonly Subject<IEffect> _ignitionEffectSubject;

        public IEffect Effect { get; }
        public bool Enabled { get; private set; }

        public IObservable<IEffect> IgnitionEffectObservable =>
            _ignitionEffectSubject.AsObservable();

        protected SkillObject(
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
            cooldownTimeSubject
        )
        {
            _ignitionEffectSubject = new Subject<IEffect>();

            Effect = effect;
            Enabled = false;
        }

        public override void Action()
        {
            if (!IsViable()) return;

            _ignitionEffectSubject.OnNext(Effect);

            base.Action();
        }

        /// <summary>
        /// 使用可否を切り替える
        /// </summary>
        /// <param name="enabled">使用可否</param>
        public void SetEnabled(bool enabled)
        {
            Enabled = enabled;
        }

        protected override bool IsViable()
        {
            return Enabled && base.IsViable();
        }
    }
}