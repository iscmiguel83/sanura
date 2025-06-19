using System.Runtime.Serialization;

namespace Sanura.Core.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException()
            : base()
        {

        }

        public BusinessException(string message)
            : base(message)
        {

        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected BusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
