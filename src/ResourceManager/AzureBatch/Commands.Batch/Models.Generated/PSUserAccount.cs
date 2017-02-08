﻿// -----------------------------------------------------------------------------
﻿//
﻿// Copyright Microsoft Corporation
﻿// Licensed under the Apache License, Version 2.0 (the "License");
﻿// you may not use this file except in compliance with the License.
﻿// You may obtain a copy of the License at
﻿// http://www.apache.org/licenses/LICENSE-2.0
﻿// Unless required by applicable law or agreed to in writing, software
﻿// distributed under the License is distributed on an "AS IS" BASIS,
﻿// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
﻿// See the License for the specific language governing permissions and
﻿// limitations under the License.
﻿// -----------------------------------------------------------------------------
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Batch.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.Azure.Batch;
    
    
    public partial class PSUserAccount
    {
        
        internal Microsoft.Azure.Batch.UserAccount omObject;
        
        public PSUserAccount(string name, string password, System.Nullable<Microsoft.Azure.Batch.Common.ElevationLevel> elevationLevel = null, string sshPrivateKey = null)
        {
            this.omObject = new Microsoft.Azure.Batch.UserAccount(name, password, elevationLevel, sshPrivateKey);
        }
        
        internal PSUserAccount(Microsoft.Azure.Batch.UserAccount omObject)
        {
            if ((omObject == null))
            {
                throw new System.ArgumentNullException("omObject");
            }
            this.omObject = omObject;
        }
        
        public Microsoft.Azure.Batch.Common.ElevationLevel? ElevationLevel
        {
            get
            {
                return this.omObject.ElevationLevel;
            }
            set
            {
                this.omObject.ElevationLevel = value;
            }
        }
        
        public string Name
        {
            get
            {
                return this.omObject.Name;
            }
            set
            {
                this.omObject.Name = value;
            }
        }
        
        public string Password
        {
            get
            {
                return this.omObject.Password;
            }
            set
            {
                this.omObject.Password = value;
            }
        }
        
        public string SshPrivateKey
        {
            get
            {
                return this.omObject.SshPrivateKey;
            }
            set
            {
                this.omObject.SshPrivateKey = value;
            }
        }
    }
}
