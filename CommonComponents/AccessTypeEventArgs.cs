namespace CommonComponents
{
    public class AccessTypeEventArgs : IAccessTypeEventArgs
    {
        private bool _valuesWereChanged;
        private AccessType _accessTypeValue;

        public enum AccessType
        {
            Read,
            Add,
            Update,
            Delete
        }



        public bool ValuesWereChanged
        {
            get { return _valuesWereChanged; }
            set { _valuesWereChanged = value; }
        }

        public AccessType AccessTypeValue
        {
            get { return _accessTypeValue; }
            set { _accessTypeValue = value; }
        }
    }
}
