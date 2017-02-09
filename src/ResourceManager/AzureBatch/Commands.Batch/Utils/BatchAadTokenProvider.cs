﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Batch.Utils
{
    using Common.Authentication.Models;
    using Rest;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Http.Headers;
    using System.Threading;
    using Common.Authentication;
    using IdentityModel.Clients.ActiveDirectory;

    internal class BatchAadTokenProvider : Microsoft.Rest.ITokenProvider
    {
        private const string BearerAuthScheme = "Bearer";

        private AzureContext azureContext;

        public BatchAadTokenProvider(AzureContext azureContext)
        {
            this.azureContext = azureContext;
        }

        public Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken)
        {
            string token = GetBatchAadToken();
            AuthenticationHeaderValue authHeader = new AuthenticationHeaderValue(BearerAuthScheme, token);
            return Task.FromResult(authHeader);
        }

        protected virtual string GetBatchAadToken()
        {
            if (!this.azureContext.Environment.Endpoints.ContainsKey(AzureEnvironment.Endpoint.BatchEndpointResourceId))
            {
                // Default to public cloud if key is not present.
                this.azureContext.Environment.Endpoints[AzureEnvironment.Endpoint.BatchEndpointResourceId] = AzureEnvironmentConstants.BatchEndpointResourceId;
            }

            IAccessToken tokenResult = AzureSession.AuthenticationFactory.Authenticate(this.azureContext.Account, this.azureContext.Environment,
                this.azureContext.Tenant.Id.ToString(), null, ShowDialog.Auto, TokenCache.DefaultShared,
                AzureEnvironment.Endpoint.BatchEndpointResourceId);

            return tokenResult.AccessToken;
        }
    }
}