// ***********************************************************************
// <copyright file="IItemService.cs" company="FactSet">
//     Copyright © FactSet, All Rights Reserved.
// </copyright>
// <summary>IItemService Class</summary>
// ***********************************************************************
namespace TSW.B2B.BusinessServices.Interfaces {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public interface IItemService {
		IEnumerable<BusinessObjects.Item> GetItems();
		IEnumerable<BusinessObjects.Item> GetItems(int pageNo, int pageSize);
		BusinessObjects.Item GetItemById(int id);
		bool DeleteById(int id);
		bool AddItem(BusinessObjects.Item item);
	}
}
