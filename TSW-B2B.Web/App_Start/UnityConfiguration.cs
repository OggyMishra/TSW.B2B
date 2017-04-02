namespace TSW_B2B.Web.App_Start {

	using System;
	using Microsoft.Practices.Unity;
	using TSW.B2B.BusinessServices.Classes;
	using TSW.B2B.BusinessServices.Interfaces;
	using TSW.B2B.Common.Implementation;
	using TSW.B2B.Common.Interfaces;
	using TSW.B2B.Repositories.Classes;
	using TSW.B2B.Repositories.Interfaces;

	public class UnityConfiguration {
		#region Unity Container

		/// <summary>
		/// The unityContainer.
		/// </summary>
		private static readonly Lazy<IUnityContainer> unityContainer = new Lazy<IUnityContainer>(() =>
		{
			var container = new UnityContainer();
			RegisterTypes(container);
			return container;
		});

		/// <summary>
		/// Gets the configured Unity unityContainer.
		/// </summary>
		/// <returns>
		/// The <see cref="IUnityContainer"/>.
		/// </returns>
		public static IUnityContainer GetConfiguredContainer() {
			return unityContainer.Value;
		}
		#endregion

		#region InstancesRegistration        
		/// <summary>
		/// Registers the types.
		/// </summary>
		/// <param name="container">The container.</param>
		private static void RegisterTypes(UnityContainer container) {
			container.RegisterType(typeof(IItemService), typeof(ItemService));
			container.RegisterType(typeof(IItemRepository), typeof(ItemRepository));
			container.RegisterType(typeof(IConnectionFactory), typeof(DbConnectionFactory));
			container.RegisterType(typeof(IDbContext), typeof(DbContext));
			container.RegisterType(typeof(ITransactionService), typeof(TransactionService));
		}
		#endregion
	}
}