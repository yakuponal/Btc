using Btc.Notification.Data.Entities.Abstractions;
using Btc.Notification.Data.Repositories;
using Btc.Notification.Data.Repositories.Abstractions;
using Btc.Notification.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Btc.Notification.Data.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            services.AddSingleton(a =>
            {
                var mongoClient = new MongoClient(configuration["MongoDbSettings:ConnectionString"]);
                return mongoClient.GetDatabase(configuration["MongoDbSettings:Database"]);
            });
        }

        public static void AddMongoRepository<T>(this IServiceCollection services, string collectionName) where T : IEntity
        {
            services.AddSingleton<IRepository<T>>(a =>
            {
                var database = a.GetService<IMongoDatabase>();
                return new MongoRepository<T>(database, collectionName);
            });
        }
    }
}
