using System;
using UniRx;

namespace Game.Viable.Core
{
    /// <summary>
    /// 影響を及ぼす実行可能オブジェクトでアイテムに該当するもの
    /// </summary>
    public abstract class InstantItemObject : ViableObject, IEffectiveObject
    {
        private readonly Subject<IEffect> _ignitionEffectSubject;

        public IEffect Effect { get; }
        public bool Enabled => true;

        public IObservable<IEffect> IgnitionEffectObservable =>
            _ignitionEffectSubject.AsObservable();

        protected InstantItemObject(
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
        }

        public override void Action()
        {
            if (!IsViable()) return;

            _ignitionEffectSubject.OnNext(Effect);

            base.Action();
        }
    }
}