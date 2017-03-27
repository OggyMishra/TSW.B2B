namespace TSW.B2B.BusinessObjects
{
    using System.Collections.Generic;
    
    public class BaseResult<T> where T : class
	{
        public IList<T> Results { get; set; }

        public int TotalRecords { get; set; }

        public bool Status { get; set; }

        public string Message { get; set; }
	}
}