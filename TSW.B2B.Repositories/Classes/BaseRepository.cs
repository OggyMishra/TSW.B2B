
namespace TSW.B2B.Repositories
{
    using System;
    using System.Configuration;
    using Interfaces;

    public class BaseRepository : IBaseRepository
    {
        //private string dataBaseName = "";

        //protected IDbContext GetMasterDBInstance()
        //{
        //    return this.GetDataBase(this.dataBaseName);
        //}


        //protected IDbContext GetCustomerDBInstance(string tenantId)
        //{
        //    return this.GetDataBase($"{this.dataBaseName}_{tenantId}");

        //}
        
        //private IDbContext GetDataBase(string dbName)
        //{
        //    var settings = MongoClientSettings.FromUrl(new MongoUrl(this.dataBaseConnection));
        //    MongoClient client = new MongoClient(settings);
        //    IDbContext database = client.GetDatabase(dbName);

        //    if (database == null)
        //    {
        //        throw new InvalidOperationException($"{DataBaseNotFoundMessage}{dbName}");
        //    }
        //    return database;
        //}

        //public void DropCollection(string tenantId,string collectionName) {
        //    var client = this.GetCustomerDBInstance(tenantId);
        //    client.DropCollection(collectionName);
        //}
    }
}
