using System;
using System.Collections.Generic;



namespace ConsolProject
{
	public class ServiceLocator
	{

		public static ServiceLocator sharedInstance = new ServiceLocator();

		private  Dictionary<Type, object> serviceDictionary = new Dictionary<Type, object>();

		private ServiceLocator()
		{
			registerServices();
		}

		private void registerServices()
		{
			serviceDictionary[typeof(IDataProvider)] = new DataProviderImplementation();//DataProviderImplementation;
		}


		public T getService<T>()
		{
			object service;
			if (serviceDictionary.TryGetValue(typeof(T), out service))
			{
				return (T)service;
			}
			return default(T);
		}


	}
}
