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

using Newtonsoft.Json;

namespace PgDoc.Serialization
{
    public class JsonEntity<T> : IJsonEntity<T>
        where T : class
    {
        public JsonEntity(EntityId id, T? entity, ByteString version)
        {
            Id = id;
            Entity = entity;
            Version = version;
        }

        public EntityId Id { get; }

        public ByteString Version { get; }

        public T? Entity { get; }

        public static JsonEntity<T> FromDocument(Document document)
        {
            return new JsonEntity<T>(
                new EntityId(document.Id),
                document.Body != null ? (T)JsonConvert.DeserializeObject(document.Body, typeof(T), JsonSettings.Settings) : null,
                document.Version);
        }

        public JsonEntity<T> Modify(T newValue)
        {
            return new JsonEntity<T>(Id, newValue, Version);
        }

        public static JsonEntity<T> Create(T value, EntityType type)
        {
            return new JsonEntity<T>(EntityId.New(type), value, ByteString.Empty);
        }

        public void Deconstruct(out EntityId id, out T? entity, out ByteString version)
        {
            id = Id;
            entity = Entity;
            version = Version;
        }
    }
}
