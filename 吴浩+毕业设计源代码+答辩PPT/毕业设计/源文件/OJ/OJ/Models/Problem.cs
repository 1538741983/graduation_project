namespace OJ.OJService
{
    public partial class ProblemDO
    {
        private bool pass;

        public bool Pass
        {
            get { return pass; }
            set { this.pass = value; }
        }

        private long passRate;

        public long PassRate
        {
            get { return passRate; }
            set { passRate = value; }
        }
    }
}