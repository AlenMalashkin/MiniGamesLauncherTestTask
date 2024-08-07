namespace Code.Services
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance => _instance ??= new ServiceLocator();
        private static ServiceLocator _instance;
        
        public void RegisterService<TService>(TService service) where TService : IService
            => ServiceInstance<TService>.Instance = service;
        
        public TService Resolve<TService>() where TService : IService
            => ServiceInstance<TService>.Instance;
        
        private class ServiceInstance<TService> where TService : IService
        {
            public static TService Instance;
        }
    }
}