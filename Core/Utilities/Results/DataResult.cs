﻿namespace Core.Utilities.Results
{
    public class DataResult<T> : Result,IDataResult<T>
    {
        public T Data { get; }
        public DataResult(T data, bool succes, string message) : base(succes, message)
        {
            this.Data = data;
        }
        public DataResult(T data, bool succes) : base(succes)
        {
            this.Data = data;
        }
    }
}
