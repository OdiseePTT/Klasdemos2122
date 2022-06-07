namespace PersonAgeValidator.Tests._2
{
    internal class StubAgeValidator : IAgeValidator
    {
        bool _result;

        public StubAgeValidator(bool result)
        {
            _result = result;
        }
        public bool IsValidAge(int age)
        {
            return _result;
        }
    }
}
