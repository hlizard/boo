#region license
// Copyright (c) 2009, Rodrigo B. de Oliveira (rbo@acm.org)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Rodrigo B. de Oliveira nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

using System;
using System.Security.Permissions;

namespace Boo.Lang.Compiler.Util
{
	internal static class Permissions
	{
		public static T WithEnvironmentPermission<T>(Func<T> function)
        {
#if !(DNXCORE50 || NETSTANDARD1_6 || NETSTANDARD2_0 || NET5_0)
            return WithPermission(ref hasEnvironmentPermission, () => new EnvironmentPermission(PermissionState.Unrestricted), function);
#else
			return default(T);
#endif
        }

		public static T WithDiscoveryPermission<T>(Func<T> function)
        {
#if !(DNXCORE50 || NETSTANDARD1_6 || NETSTANDARD2_0 || NET5_0)
			return WithPermission(ref hasDiscoveryPermission, () => new FileIOPermission(PermissionState.Unrestricted), function);
#else
			return default(T);
#endif
        }

#if !(DNXCORE50 || NETSTANDARD1_6 || NETSTANDARD2_0 || NET5_0)
        public static void WithAppDomainPermission(Action action)
        {
            WithPermission(ref hasAppDomainPermission,
                () => new SecurityPermission(SecurityPermissionFlag.ControlAppDomain),
                () => { action(); return false; });
        }

        static bool? hasAppDomainPermission;
        static bool? hasEnvironmentPermission;
        static bool? hasDiscoveryPermission;
#endif

		private static TRetVal WithPermission<TPermission, TRetVal>(ref bool? hasPermission, Func<TPermission> permission, Func<TRetVal> function)
		{
			if (hasPermission.HasValue && !hasPermission.Value)
				return default(TRetVal);

			try
			{
				permission();
				return function();
			}
			catch (Exception)
			{
				hasPermission = false;
				return default(TRetVal);
			}
		}
	}
}

