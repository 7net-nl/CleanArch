using AutoMapper;
using CleanArchitecture.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.DataBase.MongoDb
{
    public class MongoDbContext 
    {
        private readonly IMapper mapper;

        public MongoDbContext(IMapper mapper)
        {
            this.mapper = mapper;
        }
       


        public IMongoCollection<TEntity> Set<TEntity>() where TEntity : Entity
        {
            var Client = new MongoClient("mongodb://localhost:27017");
            var DataBase = Client.GetDatabase("CleanArchitecture");
            var Result = DataBase.GetCollection<TEntity>(typeof(TEntity).Name.Replace("Model",""));
            
           
            return Result;   
            
        }

      
    }
}
