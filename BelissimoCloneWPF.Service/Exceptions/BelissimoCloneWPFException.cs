namespace BelissimoCloneWPF.Service.Exceptions
{
    public class BelissimoCloneWPFException : Exception
    {
        public int Code { get; set; }
        public BelissimoCloneWPFException(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
