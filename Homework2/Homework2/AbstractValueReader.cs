namespace Homework2
{
    class AbstractValueReader : IInputProvider
    {
        protected string value;

        public string GetInput()
        {
            return value;
        }
    }
}