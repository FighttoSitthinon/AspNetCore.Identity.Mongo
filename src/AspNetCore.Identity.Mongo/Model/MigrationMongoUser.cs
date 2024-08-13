using System;
using System.Collections.Generic;
using DnsClient;
using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AspNetCore.Identity.Mongo.Model
{
    internal class MigrationMongoUser : MigrationMongoUser<ObjectId>
    {
        public MigrationMongoUser() : base() { }
    }

    internal class MigrationMongoUser<TKey> : IdentityUser<TKey> where TKey : IEquatable<TKey>
    {
        public MigrationMongoUser()
        {
            Roles = new List<string>();
            Claims = new List<CustomIdentityUserClaim<string>>();
            Logins = new List<IdentityUserLogin<string>>();
            Tokens = new List<IdentityUserToken<string>>();
            RecoveryCodes = new List<TwoFactorRecoveryCode>();
        }

        public string AuthenticatorKey { get; set; }

        public List<string> Roles { get; set; }

        public List<CustomIdentityUserClaim<string>> Claims { get; set; }

        public List<IdentityUserLogin<string>> Logins { get; set; }

        public List<IdentityUserToken<string>> Tokens { get; set; }

        public List<TwoFactorRecoveryCode> RecoveryCodes { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class CustomIdentityUserClaim<TKey> : IdentityUserClaim<TKey> where TKey : IEquatable<TKey>
    {
        //
        // Summary:
        //     Gets or sets the claim type for this claim.
        [BsonIgnore]
        [BsonElement("Type")]
        public override string ClaimType { get; set; }
        //
        // Summary:
        //     Gets or sets the claim value for this claim.
        [BsonIgnore]
        [BsonElement("Value")]
        public override string ClaimValue { get; set; }
    }
}
