﻿/*
 * OnSolve
 * Author: Daniel Jackson
 * NocWebUtility Application
 * Created: 03/22/2017
 * Last Edit: 09/22/2017
 * Description: Model for a Company Product.
 * 
 */
namespace NocWebUtilityApp.Models
{
	public class Product
	{
		/*----------------------------------------------------------------------------------------------------------------------
		* [fields]
		-----------------------------------------------------------------------------------------------------------------------*/

		/*----------------------------------------------------------------------------------------------------------------------
		* [properties]
		-----------------------------------------------------------------------------------------------------------------------*/
		public int Id { get; set; }
		public int TableNumber { get; set; }
		public string ProductName { get; set; }
		public string ProductGroup { get; set; }
		public string Url { get; set; }
		public string MachineText { get; set; }
		public Server PrimaryProductServer { get; set; }
		public Server SecondaryProductServer { get; set; }

		/*----------------------------------------------------------------------------------------------------------------------
		* [constructors]
		-----------------------------------------------------------------------------------------------------------------------*/

		/*----------------------------------------------------------------------------------------------------------------------
		* [methods]
		-----------------------------------------------------------------------------------------------------------------------*/

	}
}
