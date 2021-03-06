//    Copyright 2018 Andrew White
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

using System;
using System.Threading.Tasks;
using Finbuckle.MultiTenant.Core.Abstractions;
using Microsoft.Extensions.Logging;

namespace Finbuckle.MultiTenant.Core
{
    /// <summary>
    /// <c>IMultiTenantResolverStrategy</c> implementation that always resolves the same identifier.
    /// </summary>
    public class StaticMultiTenantStrategy : IMultiTenantStrategy
    {
        private readonly string identifier;
        private readonly ILogger<StaticMultiTenantStrategy> logger;

        public StaticMultiTenantStrategy(string identifier) : this(identifier, null)
        {
        }

        public StaticMultiTenantStrategy(string identifier, ILogger<StaticMultiTenantStrategy> logger)
        {
            this.identifier = identifier;
            this.logger = logger;
        }

        public virtual string GetIdentifier(object context)
        {
            Utilities.TryLogInfo(logger, $"Found identifier: \"{identifier ?? "<null>"}\"");

            return identifier;
        }
    }
}