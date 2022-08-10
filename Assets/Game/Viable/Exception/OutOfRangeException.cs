using System;
using System.Runtime.Serialization;

namespace Game.Viable.Exception
{
    [Serializable]
    public class OutOfRangeException : System.Exception
    {
        public OutOfRangeException()
        {
        }

        public OutOfRangeException(string message)
            : base(message)
        {
        }

        public OutOfRangeException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        protected OutOfRangeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}