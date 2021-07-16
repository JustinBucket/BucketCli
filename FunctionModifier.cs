using System;

namespace BucketCli
{
    public sealed class FunctionModifier
    {
        public string ShortKey { get; private set; }
        public string LongKey { get; private set; }
        public string Description { get; private set; }
        public FunctionModifier(string description, string shortKey = null, string longKey = null)
        {
            if (shortKey == null && longKey == null)
                throw new ArgumentException("Either a shortKey or a longKey must be specified");

            Description = description;

            if (shortKey != null)
                ShortKey = shortKey;

            if (longKey != null)
                LongKey = longKey;
        }
    }
}