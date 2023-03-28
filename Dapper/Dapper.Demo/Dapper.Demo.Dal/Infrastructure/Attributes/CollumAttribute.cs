namespace Dapper.Demo.Dal.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Enum)]
    internal class CollumAttribute : Attribute
    {
        public CollumAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
