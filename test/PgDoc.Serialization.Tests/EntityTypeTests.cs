﻿// Copyright 2016 Flavien Charlon
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Xunit;

namespace PgDoc.Serialization.Tests
{
    public class EntityTypeTests
    {
        [Fact]
        public void Constructor_Success()
        {
            EntityType entityType = new EntityType(10);

            Assert.Equal(10, entityType.Value);
        }

        [Fact]
        public void Equals_Success()
        {
            Assert.True(new EntityType(1).Equals(new EntityType(1)));
            Assert.False(new EntityType(1).Equals(new EntityType(2)));
            Assert.True(((object)new EntityType(1)).Equals(new EntityType(1)));
            Assert.False(new EntityType(1).Equals("string"));
            Assert.False(new EntityType(1).Equals(null));
        }

        [Fact]
        public void GetHashCode_Success()
        {
            EntityType value1 = new EntityType(1);
            EntityType value2 = new EntityType(2);
            EntityType value3 = new EntityType(1);

            Assert.Equal(value1.GetHashCode(), value3.GetHashCode());
            Assert.NotEqual(value1.GetHashCode(), value2.GetHashCode());
        }

        [Fact]
        public void Equality_Success()
        {
            Assert.True(new EntityType(1) == new EntityType(1));
            Assert.False(new EntityType(1) == new EntityType(2));
        }

        [Fact]
        public void Inequality_Success()
        {
            Assert.False(new EntityType(1) != new EntityType(1));
            Assert.True(new EntityType(1) != new EntityType(2));
        }
    }
}
