using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AspNetCore.Identity.Mongo.Model
{
    public class MongoUser : MongoUser<ObjectId>
    {
        public MongoUser() : base() { }

        public MongoUser(string userName) : base(userName) { }
    }

    public class MongoUser<TKey> : IdentityUser<TKey> where TKey : IEquatable<TKey>
    {
        public MongoUser()
        {
            Roles = new List<string>();
            Claims = new List<CustomIdentityUserClaim<string>>();
            Logins = new List<IdentityUserLogin<string>>();
            Tokens = new List<IdentityUserToken<string>>();
        }

        public MongoUser(string userName) : this()
        {
            UserName = userName;
            NormalizedUserName = userName.ToUpperInvariant();
        }

        public List<string> Roles { get; set; }

        public List<CustomIdentityUserClaim<string>> Claims { get; set; }

        public List<IdentityUserLogin<string>> Logins { get; set; }

        public List<IdentityUserToken<string>> Tokens { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class CustomIdentityUserClaim<TKey> : IdentityUserClaim<TKey> where TKey : IEquatable<TKey>
    {
        //
        // Summary:
        //     Gets or sets the claim type for this claim.
        [BsonElement("Type")]
        public override string ClaimType { get; set; }
        //
        // Summary:
        //     Gets or sets the claim value for this claim.
        [BsonElement("Value")]
        public override string ClaimValue { get; set; }
    }
}