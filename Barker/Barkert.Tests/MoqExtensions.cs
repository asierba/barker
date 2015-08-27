using System.Collections.Generic;
using Moq.Language.Flow;

namespace Barkert.Tests.Features
{
    public static class MoqExtensions
    {
        // From: http://haacked.com/archive/2009/09/29/moq-sequences.aspx/ 
        public static void ReturnsInOrder<T, TResult>(this ISetup<T, TResult> setup,
            params TResult[] results) where T : class
        {
            setup.Returns(new Queue<TResult>(results).Dequeue);
        }
    }
}