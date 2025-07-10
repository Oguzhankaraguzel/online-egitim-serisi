using System;

namespace MyNullAble
{
    public struct MyNullable<TValue>
    {
        private readonly TValue _value;
        private readonly bool _hasValue;
        public MyNullable(TValue value)
        {
            _value = value;
            _hasValue = true;
        }
        public bool HasValue
        {
            get { return _hasValue; }
        }
        public TValue Value
        {
            get
            {
                if (!_hasValue)
                {
                    throw new InvalidOperationException("Değer mevcut değil.");
                }
                return _value;
            }
        }
        public TValue GetValueOrDefault(TValue defaultValue = default)
        {
            return _hasValue ? _value : defaultValue;
        }
    }
}
