using System.Web;
using AppSoftClean.Data.Infraestructure;
using AppSoftClean.Data.Repository;
using Microsoft.Practices.Unity;
using Unity.WebForms;

[assembly: WebActivatorEx.PostApplicationStartMethod( typeof(AppSoftClean.App_Start.UnityWebFormsStart), "PostStart" )]
namespace AppSoftClean.App_Start
{
	/// <summary>
	///		Startup class for the Unity.WebForms NuGet package.
	/// </summary>
	internal static class UnityWebFormsStart
	{
		/// <summary>
		///     Initializes the unity container when the application starts up.
		/// </summary>
		/// <remarks>
		///		Do not edit this method. Perform any modifications in the
		///		<see cref="RegisterDependencies" /> method.
		/// </remarks>
		internal static void PostStart()
		{
			IUnityContainer container = new UnityContainer();
			HttpContext.Current.Application.SetContainer( container );

			RegisterDependencies( container );
		}

		/// <summary>
		///		Registers dependencies in the supplied container.
		/// </summary>
		/// <param name="container">Instance of the container to populate.</param>
		private static void RegisterDependencies( IUnityContainer container )
		{
            container.RegisterType<IAreaUsoRepository, RepositoryAreaUso>();
            container.RegisterType<ICepInBasRepository, RepositoryCepInsBas>();
            container.RegisterType<IDetalleLevantamientoRepository, RepositoryDetalleLevantamiento>();
            container.RegisterType<IDivisionesRepository, RepositoryDivisiones>();
            container.RegisterType<IDosEstLimRepository, RepositoryDosEstLimp>();
            container.RegisterType<IDosLavRepository, RepositoryDosLav>();
            container.RegisterType<ILevantamientoEquiposRepository, RepositoryLevantamientoEquipos>();
            container.RegisterType<IModEqDosRepository, RepositoryModEqDos>();
            container.RegisterType<IModJabRepository, RepositoryModJab>();
            container.RegisterType<IPedidosAreaRepository, RepositoryPedidosArea>();
            container.RegisterType<IPortGalonRepository, RepositoryPortGalon>();
            container.RegisterType<IProdQuimRepository, RepositoryProdQuim>();
            container.RegisterType<ITipMaqLavRepository, RepositoryTipMaqLav>();
        }
	}
}