using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Core.Aspects.Postsharp.CacheAspects
{
    /// <summary>
    ///   Custom attribute that, when applied to a method, caches the return value of the method according to parameter values.
    /// </summary>
    [Serializable]
    public sealed class MyCacheAspect : OnMethodBoundaryAspect
    {
        /// <summary>
        ///   Method executed <i>before</i> the target method of the aspect.
        /// </summary>
        /// <param name="args">Method execution context.</param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            // Build the cache key.
            var stringBuilder = new StringBuilder();
            AppendCallInformation(args, stringBuilder);
            var cacheKey = stringBuilder.ToString();

            // Get the value from the cache.
            var cachedValue = MemoryCache.Default.Get(cacheKey);

            if (cachedValue != null)
            {
                // If the value is already in the cache, don't even execute the method. Set the return value from the cache and return immediately.
                args.ReturnValue = cachedValue;
                args.FlowBehavior = FlowBehavior.Return;
            }
            else
            {
                // If the value is not in the cache, continue with method execution, but store the cache key so we can reuse it when the method exits.
                args.MethodExecutionTag = cacheKey;
                args.FlowBehavior = FlowBehavior.Continue;
            }
        }

        /// <summary>
        ///   Method executed <i>after</i> the target method of the aspect.
        /// </summary>
        /// <param name="args">Method execution context.</param>
        public override void OnSuccess(MethodExecutionArgs args)
        {
            var cacheKey = (string)args.MethodExecutionTag;
            MemoryCache.Default[cacheKey] = args.ReturnValue;
        }


        private static void AppendCallInformation(MethodExecutionArgs args, StringBuilder stringBuilder)
        {
            // Append type and method name.
            var declaringType = args.Method.DeclaringType;
            Formatter.AppendTypeName(stringBuilder, declaringType);
            stringBuilder.Append('.');
            stringBuilder.Append(args.Method.Name);

            // Append generic arguments.
            if (args.Method.IsGenericMethod)
            {
                var genericArguments = args.Method.GetGenericArguments();
                Formatter.AppendGenericArguments(stringBuilder, genericArguments);
            }

            // Append arguments.
            Formatter.AppendArguments(stringBuilder, args.Arguments);
        }
    }
}


