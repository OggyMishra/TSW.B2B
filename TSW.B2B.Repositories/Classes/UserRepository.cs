namespace TSW.B2B.Repositories.Classes {
	using System;
	using System.Threading.Tasks;
	using Entities;
	using Repositories.Interfaces;


	public sealed class UserRepository : IUserRepository {
		public UserRepository(IBaseRepository baseRepository) {
		}


		public async Task AddNewUser(User user) {
			throw new NotImplementedException();
			//   var usersCollection = this.mongoServer.GetMasterDBInstance().GetCollection<User>(Collection.Users);
			// await usersCollection.InsertOneAsync(user);
		}


		public async Task<bool> UpdateUser(User user) {
			throw new NotImplementedException();
		}
	}
}