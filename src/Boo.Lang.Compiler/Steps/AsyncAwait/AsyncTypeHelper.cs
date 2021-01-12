using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boo.Lang.Compiler.TypeSystem;
using Boo.Lang.Environments;

namespace Boo.Lang.Compiler.Steps.AsyncAwait
{
    internal static class AsyncTypeHelper
    {
        private static readonly IType _typeReferenceType;
#if !(DNXCORE50 || NETSTANDARD1_6 || NETSTANDARD2_0 || NET5_0)
        private static readonly IType _argIteratorType;
#endif
        private static readonly IType _runtimeArgumentHandleType;

        static AsyncTypeHelper()
        {
            var tss = My<TypeSystemServices>.Instance;
            _typeReferenceType = tss.Map(typeof(System.TypedReference));
#if !(DNXCORE50 || NETSTANDARD1_6 || NETSTANDARD2_0 || NET5_0)
            _argIteratorType = tss.Map(typeof(System.ArgIterator));
#endif
            _runtimeArgumentHandleType = tss.Map(typeof(System.RuntimeArgumentHandle));
        }

        public static bool IsRestrictedType(this IType type)
        {
#if !(DNXCORE50 || NETSTANDARD1_6 || NETSTANDARD2_0 || NET5_0)
            return type == _typeReferenceType || type == _argIteratorType || type == _runtimeArgumentHandleType;
#else
            return type == _typeReferenceType || type == _runtimeArgumentHandleType;
#endif
        }

        internal static bool IsVerifierReference(this IType type)
        {
            return !type.IsValueType && type.EntityType != EntityType.GenericParameter;
        }
    }
}
