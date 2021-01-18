namespace RicisBatch.Job
{
    public class JobParameter
    {
        public string Parametername { get;  }
        public object Value { get;  }

        public JobParameter(string parametername, object value)
        {
            Parametername = parametername;
            Value = value;
        }
    }
}
