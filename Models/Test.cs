namespace RecruitmentSystem.Models
{
    public abstract class Test
    {
        public bool Passed { get; private set; }
        protected Test(bool passed)
        {
            Passed = passed;
        }
        public void SetTestResult(bool passed)
        {
            Passed = passed;
        }
    }
}
