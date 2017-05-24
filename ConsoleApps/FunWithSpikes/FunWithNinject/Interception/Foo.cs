namespace FunWithNinject.Interception
{
    public class Foo
    {
        /// <remarks>
        /// In order to be intercepted, the 
        /// property MUST be marked as virtual
        /// </remarks>
        public virtual int Bar(string input)
        {
            return input?.Length ?? -1;
        }
    }
}