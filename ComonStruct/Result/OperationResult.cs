namespace ComonStruct.Result
{
    public class OperationResult
    {
        #region CTOR
        public bool Result { get; }
        public string Message { get; }

        protected OperationResult(bool result)
            : this(result, string.Empty)
        {
        }

        protected OperationResult(bool result, string message)
        {
            Result = result;
            Message = message;
        }
        #endregion

        #region Result creater
        public static OperationResult Success()
        {
            return Success(string.Empty);
        }
        public static OperationResult Success(string message)
        {
            return new OperationResult(true, message);
        }



        public static OperationResult Fault()
        {
            return Fault(string.Empty);
        }
        public static OperationResult Fault(string message)
        {
            return new OperationResult(false, message);
        }

        #endregion

        public static implicit operator bool(OperationResult operationResult) => operationResult.Result;
    }

    public class OperationResult<T> : OperationResult
    {
        #region CTOR
        public T Value { get; }

        protected OperationResult(bool result) : base(result)
        {
        }

        protected OperationResult(bool result, string message) : base(result, message)
        {
        }

        protected OperationResult(bool result, string message, T value) : base(result, message)
        {
            Value = value;
        }
        #endregion

        #region Result creater
        public new static OperationResult<T> Success()
        {
            return Success(string.Empty);
        }
        public new static OperationResult<T> Success(string message)
        {
            T def = default;
            return Success(message, def);
        }
        public static OperationResult<T> Success(T value)
        {
            return Success(string.Empty, value);
        }
        public static OperationResult<T> Success(string message, T value)
        {
            return new OperationResult<T>(true, message, value);
        }



        public new static OperationResult<T> Fault()
        {
            return Fault(string.Empty);
        }

        public new static OperationResult<T> Fault(string message)
        {
            T def = default;
            return Fault(message, def);
        }
        public static OperationResult<T> Fault(T value)
        {
            return Fault(string.Empty, value);
        }
        public static OperationResult<T> Fault(string message, T value)
        {
            return new OperationResult<T>(false, message, value);
        }
        #endregion
    }
}
