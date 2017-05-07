namespace PiggyMetrics.Common
{
    public partial class Account
    {
        public string Current{
            get{
                return this.Name;
            }
            set{
                this.Name = value;
            }
        }
    }
}
